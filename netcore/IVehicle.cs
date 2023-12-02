using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public enum VehicleEnum
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
    public interface IVehicle
    {
        VehicleEnum Type { get; }
    }

    public static class VehicleFactory
    {
        public static IVehicle Create(VehicleEnum vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleEnum.Motorcycle:
                    return new Motorbike();
                case VehicleEnum.Car:
                    return new Car();
                default:
                    throw new ArgumentOutOfRangeException(nameof(vehicleType));
            }
        }
    }
}