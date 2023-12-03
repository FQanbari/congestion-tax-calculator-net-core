using System.ComponentModel.DataAnnotations.Schema;

namespace congestion.calculator.Models
{
    public class TollFreeVehicle : BaseModel
    {
        public string Type { get; set; } // Foreign key for vehicle type
    }
    //public class VehicleType: BaseModel
    //{
    //    public string Type { get; set; } // Car, Motorbike, etc.
    //}

}
