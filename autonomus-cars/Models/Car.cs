namespace autonomus_cars.Models
{
    public class Car
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Manufacturer { get; }
        public string Model { get; }
        public double Speed { get; private set; }
        public Location CurrentLocation { get; private set; }
        public List<CarEvent> CarEvents { get; } = new List<CarEvent>();

        private double _carMileage;

        public Car(string manufacturer, string model)
        {
            Manufacturer = manufacturer;
            Model = model;
            _carMileage = 0;
        }


        public void SetSpeed(double speed)
        {
            Speed = speed >= 0 ? speed : throw new ArgumentException("Speed cannot be negative");
        }

        public void SetLocation(Location location)
        {
            CurrentLocation = location;
        }

        public void UpdateLocation(Location newLocation)
        {
            double distance = CurrentLocation.DistanceTo(newLocation);
            _carMileage += distance;

            CurrentLocation = newLocation;

            RemovePastEvents();
        }

        public void AddEvent(string eventDescription)
        {
            CarEvent newEvent = new CarEvent(eventDescription, CurrentLocation, _carMileage);
            CarEvents.Add(newEvent);
        }

        private void RemovePastEvents()
        {
            CarEvents.RemoveAll(e => _carMileage - e.EventAtMileage > 100);
        }
    }
}
