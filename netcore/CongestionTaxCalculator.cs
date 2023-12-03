using System;
using System.Collections.Generic;
using System.Linq;
using congestion.calculator.Models;
using congestion.calculator.Service;
public class CongestionTaxCalculator
{
    private readonly List<TollTaxRule> _taxRules;
    private readonly List<TollFreeVehicle> _tollFreeVehicleTypes;
    private const int _maximumTollTaxPerDay = 60;
    private const int _singlChargeRuleIntervalInMinutes = 60;

    public CongestionTaxCalculator(List<TollTaxRule> taxRules, List<TollFreeVehicle> tollFreeVehicles)
    {

        // Initialize tax rules
        _taxRules = taxRules;

        // Initialize toll-free vehicle types
        _tollFreeVehicleTypes = tollFreeVehicles;
    }
   
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    public int GetTax(IVehicle vehicle, DateTime[] dates)
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

    private bool IsTollFreeVehicle(IVehicle vehicle)
    {
        if (vehicle == null) return false;

        return _tollFreeVehicleTypes.Any(x => x.Type == vehicle.Type.ToString());
    }

    public int GetTollFee(DateTime date, IVehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle))
            return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        foreach (var rule in _taxRules)
        {
            if (hour == rule.StartTime.Hours && minute >= rule.StartTime.Minutes && minute <= rule.EndTime.Minutes)
            {
                return rule.Amount;
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