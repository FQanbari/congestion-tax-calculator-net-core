using congestion.calculator.Config;
using congestion.calculator.Configuration;
using congestion.calculator.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace congestion.calculator.Domain
{
    public class CongestionTaxCalculator
    {
        //private readonly CityTaxConfiguration _cityTaxConfiguration;
        private readonly ICityTaxConfigurationLoader _loader;
        private const int MaximumTollTaxPerDay = 60;
        private const int SinglChargeRuleIntervalInMinutes = 60;

        public CongestionTaxCalculator(ICityTaxConfigurationLoader loader)
        {
            _loader = loader;

        }

        public int GetTax(Vehicle vehicle, DateTime[] dates)
        {
            if (dates == null || dates.Length == 0 || vehicle == null)
            {
                return 0;
            }

            int totalFee = 0;
            DateTime previousDate = dates[0];
            int currentFee = GetTollFee(previousDate, vehicle);

            foreach (DateTime currentDate in dates.Skip(1))
            {
                int nextFee = GetTollFee(currentDate, vehicle);

                if (IsWithinSameHour(previousDate, currentDate))
                {
                    currentFee = Math.Max(currentFee, nextFee);
                }
                else
                {
                    totalFee += currentFee;
                    currentFee = nextFee;
                }

                previousDate = currentDate;
            }

            totalFee += currentFee;
            return Math.Min(totalFee, MaximumTollTaxPerDay); // Maximum amount per day is 60 SEK
        }
        private bool IsWithinSameHour(DateTime date1, DateTime date2)
        {
            TimeSpan timeDifference = date2 - date1;
            return timeDifference.TotalMinutes <= SinglChargeRuleIntervalInMinutes;
        }
        private bool IsTollFreeVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return false;
            }
            return _loader.LoadConfiguration().TollFreeVehicles.Any(x => x.Vehicle.Contains(vehicle.GetVehicleType().ToLower()));
        }

        private bool IsTollFreeDate(DateTime date)
        {

            var tollFreeDates = _loader.LoadConfiguration().TollFreeDates
                .Select(dateString => dateString.Date)
                .ToHashSet();

            return tollFreeDates.Contains(date);
        }

        private int GetTollFee(DateTime date, Vehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;


            foreach (var timeInterval in _loader.LoadConfiguration().TimeIntervals)
            {
                var startHour = timeInterval.StartTime.Hours;
                var startMinute = timeInterval.StartTime.Minutes;
                var endHour = timeInterval.EndTime.Hours;
                var endMinute = timeInterval.StartTime.Minutes;

                if (IsInTimeRange(hour, minute, startHour, startMinute, endHour, endMinute))
                {
                    return timeInterval.Amount;
                }
            }

            return 0;
        }
        private bool IsInTimeRange(int hour, int minute, int startHour, int startMinute, int endHour, int endMinute)
        {
            if (hour == startHour && minute >= startMinute && minute <= endMinute)
            {
                return true;
            }

            return hour > startHour && hour <= endHour && minute >= startMinute;
        }

    }
}
