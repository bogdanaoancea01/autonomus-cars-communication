using System;
using System.Collections.Generic;
using System.Text;

namespace autonomus_cars.Models
{
    public class CarEvent
    {
        public string EventDescription { get; set; }
        public Location EventLocation { get; set; }
        public double EventAtMileage { get; set; }

        public CarEvent(string eventDescription, Location location, double eventAtMileage)
        {
            EventDescription = eventDescription;
            EventLocation = location;
            EventAtMileage = eventAtMileage;
        }
    }
}
