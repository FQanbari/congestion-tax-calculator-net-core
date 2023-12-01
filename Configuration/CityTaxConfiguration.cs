using congestion.calculator.Data;
using congestion.calculator.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Config
{
    public class CityTaxConfiguration
    {
        public List<TollFreeVehicle> TollFreeVehicles { get; set; }
        public List<TollFreeDate> TollFreeDates { get; set; }
        public List<TimeInterval> TimeIntervals { get; set; }
    }
}
