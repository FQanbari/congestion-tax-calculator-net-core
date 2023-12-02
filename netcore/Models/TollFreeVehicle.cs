using System.ComponentModel.DataAnnotations.Schema;

namespace congestion.calculator.Models
{
    public class TollFreeVehicle : BaseModel
    {
        public int VehicleId { get; set; } // Foreign key for vehicle type
        public int CityId { get; set; } // Foreign key for city-specific exemptions
        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
    }
    //public class VehicleType: BaseModel
    //{
    //    public string Type { get; set; } // Car, Motorbike, etc.
    //}

}
