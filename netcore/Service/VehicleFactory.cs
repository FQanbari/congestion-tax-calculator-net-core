using congestion.calculator.Vehicles;
using System;

namespace congestion.calculator.Service
{
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