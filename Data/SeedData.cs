//using System;
//using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using congestion.calculator.Models;

namespace congestion.calculator.Data
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            var tollFreeDates = new List<TollFreeDate>
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
            foreach (var item in tollFreeDates)
            {
                if (dbContext.TollFreeDates.Any(c => c.Date == item.Date))
                    continue;
                dbContext.TollFreeDates.Add(item);
            }
            dbContext.SaveChanges();

            var tollFreeVehicles = new List<TollFreeVehicle>
            {
                new TollFreeVehicle{ Vehicle = Vehicles.Emergency.ToString()},
                new TollFreeVehicle{ Vehicle = Vehicles.Bus.ToString()},
                new TollFreeVehicle{ Vehicle = Vehicles.Diplomat.ToString()},
                new TollFreeVehicle{ Vehicle = Vehicles.Motorcycle.ToString()},
                new TollFreeVehicle{ Vehicle = Vehicles.Military.ToString()},
                new TollFreeVehicle{ Vehicle = Vehicles.Foreign.ToString()},
            };
            foreach (var item in tollFreeVehicles)
            {
                if (dbContext.TollFreeVehicles.Any(c => c.Vehicle == item.Vehicle))
                    continue;
                dbContext.TollFreeVehicles.Add(item);
            }
            dbContext.SaveChanges();

            var timeintervals = new List<TimeInterval>
        {
            new TimeInterval { Amount = 8, StartTime = TimeSpan.FromHours(6), EndTime = TimeSpan.FromMinutes(29) },
            new TimeInterval { Amount = 13, StartTime = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromMinutes(59) },
            new TimeInterval { Amount = 18, StartTime = TimeSpan.FromHours(7), EndTime = TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(59)) },
            new TimeInterval { Amount = 13, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(29)) },
            new TimeInterval { Amount = 8, StartTime = TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(14).Add(TimeSpan.FromMinutes(59)) },
            new TimeInterval { Amount = 13, StartTime = TimeSpan.FromHours(15), EndTime = TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(29)) },
            new TimeInterval { Amount = 18, StartTime = TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(16).Add(TimeSpan.FromMinutes(59)) },
            new TimeInterval { Amount = 13, StartTime = TimeSpan.FromHours(17), EndTime = TimeSpan.FromHours(17).Add(TimeSpan.FromMinutes(59)) },
            new TimeInterval { Amount = 8, StartTime = TimeSpan.FromHours(18), EndTime = TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(29)) },
            new TimeInterval { Amount = 0, StartTime = TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(5).Add(TimeSpan.FromMinutes(59)) },
        };
            foreach (var item in timeintervals)
            {
                if (dbContext.TimeIntervals.Any(c => c.Amount == item.Amount))
                    continue;
                dbContext.TimeIntervals.Add(item);
            }
            dbContext.SaveChanges();
        }
    }
}
