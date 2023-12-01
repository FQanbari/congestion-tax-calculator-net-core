//using System;
//using System.Data.Entity;
using System;

namespace congestion.calculator.Models
{
    public class TimeInterval
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
