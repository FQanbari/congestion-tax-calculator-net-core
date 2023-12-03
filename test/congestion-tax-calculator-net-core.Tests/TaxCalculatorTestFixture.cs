using congestion.calculator;
using congestion.calculator.Models;
using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_net_core.Tests
{
    public class TaxCalculatorTestFixture
    {
        public List<TollFreeVehicle> TollFreeVehicles { get; private set; } 
        public List<TollTaxRule> TollTaxRules { get; private set; } 
        public List<TollFreeDate> TollFreeDates { get; private set; } 
        public TaxCalculatorTestFixture()
        {
            Seed();
        }

        public void Seed()
        {
            TollFreeDates = new List<TollFreeDate>
            {
                new TollFreeDate { Date = new DateTime(2013, 1, 1) },        // New Year's Day             
                new TollFreeDate { Date = new DateTime(2013, 3, 28) },       // Holy Saturday
                new TollFreeDate { Date = new DateTime(2013, 3, 29) },       // Good Friday 
                new TollFreeDate { Date = new DateTime(2013, 4, 1) },        // Easter Monday
                new TollFreeDate { Date = new DateTime(2013, 4, 30) },       // Walpurgis Night
                new TollFreeDate { Date = new DateTime(2013, 5, 1) },        // May Day
                new TollFreeDate { Date = new DateTime(2013, 5, 8) },        // Ascension Day
                new TollFreeDate { Date = new DateTime(2013, 5, 9) },        // Whit Friday
                new TollFreeDate { Date = new DateTime(2013, 6, 5) },        // National Day
                new TollFreeDate { Date = new DateTime(2013, 6, 6) },        // Midsummer Day
                new TollFreeDate { Date = new DateTime(2013, 6, 21) },       // Midsummer Eve
                new TollFreeDate { Date = new DateTime(2013, 7, 6) },        // Crown Princess Victoria's Wedding
                new TollFreeDate { Date = new DateTime(2013, 7, 7) },        // Crown Princess Victoria's Wedding
                new TollFreeDate { Date = new DateTime(2013, 11, 1) },       // All Saints' Day
                new TollFreeDate { Date = new DateTime(2013, 12, 24) },      // Christmas Eve
                new TollFreeDate { Date = new DateTime(2013, 12, 25) },      // Christmas Day
                new TollFreeDate { Date = new DateTime(2013, 12, 26) },      // Boxing Day
                new TollFreeDate { Date = new DateTime(2013, 12, 31) }       // New Year's Eve
           
            };

            TollFreeVehicles = new List<TollFreeVehicle>
            {
                new TollFreeVehicle{ Type = VehicleEnum.Emergency.ToString()},
                new TollFreeVehicle{ Type = VehicleEnum.Bus.ToString()},
                new TollFreeVehicle{ Type = VehicleEnum.Diplomat.ToString()},
                new TollFreeVehicle{ Type = VehicleEnum.Motorcycle.ToString()},
                new TollFreeVehicle{ Type = VehicleEnum.Military.ToString()},
                new TollFreeVehicle{ Type = VehicleEnum.Foreign.ToString()},
            };;

            TollTaxRules = new List<TollTaxRule>
        {
            new TollTaxRule { Amount = 8, StartTime = TimeSpan.FromHours(6), EndTime = TimeSpan.FromMinutes(29) },
            new TollTaxRule { Amount = 13, StartTime = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromMinutes(59) },
            new TollTaxRule { Amount = 18, StartTime = TimeSpan.FromHours(7), EndTime = TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(59)) },
            new TollTaxRule { Amount = 13, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(29)) },
            new TollTaxRule { Amount = 8, StartTime = TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(14).Add(TimeSpan.FromMinutes(59)) },
            new TollTaxRule { Amount = 13, StartTime = TimeSpan.FromHours(15), EndTime = TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(29)) },
            new TollTaxRule { Amount = 18, StartTime = TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(16).Add(TimeSpan.FromMinutes(59)) },
            new TollTaxRule { Amount = 13, StartTime = TimeSpan.FromHours(17), EndTime = TimeSpan.FromHours(17).Add(TimeSpan.FromMinutes(59)) },
            new TollTaxRule { Amount = 8, StartTime = TimeSpan.FromHours(18), EndTime = TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(29)) },
            new TollTaxRule { Amount = 0, StartTime = TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(5).Add(TimeSpan.FromMinutes(59)) },
        };
           
        }
    }
}
