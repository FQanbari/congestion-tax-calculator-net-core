using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using congestion.calculator.Service;

namespace congestion.calculator.Vehicles
{
    public class Car : IVehicle
    {
        public VehicleEnum Type => VehicleEnum.Car;
    }
}