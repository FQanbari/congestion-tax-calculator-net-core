using congestion.calculator.Models;
using System;

namespace congestion.calculator.Configuration
{
    public static class VehicleFactory
    {
        public static Vehicle Create(Vehicles vehicleType)
        {
            switch (vehicleType)
            {
                case Vehicles.Motorcycle:
                    return new Motorbike();
                case Vehicles.Car:
                    return new Car();
                default:
                    throw new ArgumentOutOfRangeException(nameof(vehicleType));
            }
        }
    }

}
