//using System;
//using System.Data.Entity;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace congestion.calculator.Models
{
    public enum Vehicles
    {
        Motorcycle = 0,
        Tractor = 1,
        Emergency = 2,
        Diplomat = 3,
        Foreign = 4,
        Military = 5,
        Bus = 6,
        Car = 7
    }
    public class TollFreeVehicle
    {
        public string Vehicle { get; set; }
    }
}
