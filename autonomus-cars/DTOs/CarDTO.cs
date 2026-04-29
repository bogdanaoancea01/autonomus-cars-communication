using autonomus_cars.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace autonomus_cars.DTOs
{
    public class CarDTO
    {
        public Guid Id { get; init; }
        public string Manufacturer { get; init; }
        public string Model { get; init; }
        public double Speed { get; init; }
        public Location CurrentLocation { get; init; }
        public List<CarEvent> CarEvents { get; init; }
    }
}
