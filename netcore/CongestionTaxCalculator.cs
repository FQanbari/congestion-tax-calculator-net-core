using System;
using System.Collections.Generic;
using congestion.calculator;
public class CongestionTaxCalculator
{
    private readonly List<DateTime> tollFreeDates;
    private readonly List<(TimeSpan startTime, TimeSpan endTime, int amount)> taxRules;
    private readonly HashSet<VehicleEnum> tollFreeVehicleTypes;
    private const int _maximumTollTaxPerDay = 60;
    private const int _singlChargeRuleIntervalInMinutes = 60;

    public CongestionTaxCalculator()
    {
        
        // Initialize tax rules
        taxRules = new List<(TimeSpan startTime, TimeSpan endTime, int amount)>
        {
            (new TimeSpan(6, 0, 0), new TimeSpan(6, 29, 0), 8),
            (new TimeSpan(6, 30, 0), new TimeSpan(6, 59, 0), 13),
            (new TimeSpan(7, 0, 0), new TimeSpan(7, 59, 0), 18),
            (new TimeSpan(8, 0, 0), new TimeSpan(8, 29, 0), 13),
            (new TimeSpan(8, 30, 0), new TimeSpan(14, 59, 0), 8),
            (new TimeSpan(15, 0, 0), new TimeSpan(15, 29, 0), 13),
            (new TimeSpan(15, 30, 0), new TimeSpan(16, 59, 0), 18),
            (new TimeSpan(17, 0, 0), new TimeSpan(17, 59, 0), 13),
            (new TimeSpan(18, 0, 0), new TimeSpan(18, 29, 0), 8),
            (new TimeSpan(18, 30, 0), new TimeSpan(5, 59, 0), 0),
            
        };

        // Initialize toll-free vehicle types
        tollFreeVehicleTypes = new HashSet<VehicleEnum>
        {
            VehicleEnum.Motorcycle,
            VehicleEnum.Emergency,
            VehicleEnum.Diplomat,
            VehicleEnum.Foreign,
            VehicleEnum.Military,
            VehicleEnum.Bus
        };
    }

    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    public int GetTax(Vehicle vehicle, DateTime[] dates)
    {
        if (vehicle == null || dates == null || dates.Length == 0)
            return 0;

        int totalFee = 0;
        DateTime intervalStart = dates[0];

        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(date, vehicle);
            int tempFee = GetTollFee(intervalStart, vehicle);

            long minutes = (long)(date - intervalStart).TotalMinutes;

            if (minutes <= _singlChargeRuleIntervalInMinutes)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }

            intervalStart = date;
        }

        return Math.Min(totalFee, _maximumTollTaxPerDay); // Maximum daily fee is 60
    }

    private bool IsTollFreeVehicle(Vehicle vehicle)
    {
        if (vehicle == null) return false;

        return tollFreeVehicleTypes.Contains(vehicle.Type);
    }

    public int GetTollFee(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle))
            return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        foreach (var rule in taxRules)
        {
            if (hour == rule.startTime.Hours && minute >= rule.startTime.Minutes && minute <= rule.endTime.Minutes)
            {
                return rule.amount;
            }
        }

        return 0; 
    }

    private static bool IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            return true;


        if (year == 2013)
        {
            if ((month == 1 && day == 1) ||
                (month == 3 && (day == 28 || day == 29)) ||
                (month == 4 && (day == 1 || day == 30)) ||
                (month == 5 && (day == 1 || day == 8 || day == 9)) ||
                (month == 6 && (day == 5 || day == 6 || day == 21)) ||
                (month == 7) ||
                (month == 11 && day == 1) ||
                (month == 12 && (day == 24 || day == 25 || day == 26 || day == 31)))
            {
                return true;
            }
        }

        return false;
    }
}