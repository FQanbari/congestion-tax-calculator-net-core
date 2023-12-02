using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace congestion.calculator.Models
{
    public class TollFreeDate : BaseModel
    {
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public int CityId { get; set; } // Foreign key for city-specific dates
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
    }
    //public class VehicleType: BaseModel
    //{
    //    public string Type { get; set; } // Car, Motorbike, etc.
    //}

}
