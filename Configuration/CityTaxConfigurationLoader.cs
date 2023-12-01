using congestion.calculator.Config;
using congestion.calculator.Data;
using congestion.calculator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace congestion.calculator.Configuration
{
    public class CityTaxConfigurationLoader: ICityTaxConfigurationLoader
    {
        private readonly ApplicationDbContext _db;

        public CityTaxConfigurationLoader(ApplicationDbContext db)
        {
            _db = db;
        }

        public CityTaxConfiguration LoadConfiguration()
        {
            var tollFreeDates = _db.TollFreeDates.ToList();
            var tollFreeVehicles = _db.TollFreeVehicles.ToList();
            var timeIntervals = _db.TimeIntervals.ToList();

            return new CityTaxConfiguration
            {
                TollFreeDates = tollFreeDates,
                TollFreeVehicles = tollFreeVehicles,
                TimeIntervals = timeIntervals,
            };
        }
    }
    public interface ICityTaxConfigurationLoader
    {
        CityTaxConfiguration LoadConfiguration();
    }

}
