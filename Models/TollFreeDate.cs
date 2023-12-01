//using System;
//using System.Data.Entity;

using System.ComponentModel.DataAnnotations.Schema;

namespace congestion.calculator.Models
{
    public class TollFreeDate
    {
        [Column(TypeName = "date")]
        public System.DateTime Date { get; set; }
    }
}
