using System.ComponentModel.DataAnnotations.Schema;

namespace congestion.calculator.Models
{
    public class TollRate : BaseModel
    {
        public int Hour { get; set; }
        public int Amount { get; set; }
        public int CityId { get; set; } // Foreign key for city-specific rates

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
    }
    //public class VehicleType: BaseModel
    //{
    //    public string Type { get; set; } // Car, Motorbike, etc.
    //}

}
