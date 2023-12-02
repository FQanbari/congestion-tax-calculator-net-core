using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace congestion.calculator.Models
{
    public class TaxRule : BaseModel
    {
        public int Amount { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int CityId { get; set; } // Foreign key for city-specific rates

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
    }
    //public class VehicleType: BaseModel
    //{
    //    public string Type { get; set; } // Car, Motorbike, etc.
    //}

}
