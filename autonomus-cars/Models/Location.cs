using System;
using System.Collections.Generic;
using System.Text;

namespace autonomus_cars.Models
{
    public class Location
    {
        public double X { get; }
        public double Y { get; }

        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Location other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }
    }
}
