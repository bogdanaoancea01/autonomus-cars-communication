using autonomus_cars.DTOs;
using autonomus_cars.Models;
using System.Linq;

namespace autonomus_cars.Services
{
    public class CarService : ICarService
    {
        private readonly List<Car> _carsOnRoad = new List<Car>();

        public void AddCarOnRoad(Car car)
        {
            if (_carsOnRoad.Any(c => c.Id == car.Id))
            {
                Console.WriteLine($"Car {car.Manufacturer}-{car.Model} already on road \n");
                return;
            }

            _carsOnRoad.Add(car);
        }

        public double DistanceBetweenCars(Car carA, Car carB)
        {
            return carA.CurrentLocation.DistanceTo(carB.CurrentLocation);
        }

        public Car ClosestCar(Car sourceCar)
        {
            return _carsOnRoad.Where(c => c.Id != sourceCar.Id).OrderBy(c => DistanceBetweenCars(sourceCar, c)).FirstOrDefault();
        }

        public void SendData(Car from, Car to)
        {
            var senderDTO = new CarDTO
            {
                Id = from.Id,
                Manufacturer = from.Manufacturer,
                Model = from.Model,
                Speed = from.Speed,
                CurrentLocation = from.CurrentLocation,
                CarEvents = from.CarEvents.ToList()
            };

            Console.WriteLine($"Sending data from {from.Manufacturer}-{from.Model} to {to.Manufacturer}-{to.Model}");
            ReceiveData(to, senderDTO);
            Console.WriteLine("Data sent successfully.\n");

        }

        public void ReceiveData(Car receiver, CarDTO receivedData)
        {
            Console.WriteLine("--- Car received following information ----");
            Console.WriteLine($"Car Id: {receivedData.Id}");
            Console.WriteLine($"Car Manufacturer: {receivedData.Manufacturer}");
            Console.WriteLine($"Car Model: {receivedData.Model}");
            Console.WriteLine($"Speed: {receivedData.Speed} km/h");
            Console.WriteLine($"Location: ({receivedData.CurrentLocation.X}, {receivedData.CurrentLocation.Y})");
            var events = receivedData.CarEvents.Any()
                ? string.Join(", ", receivedData.CarEvents.Select(e => e.EventDescription))
                : "No events";
            Console.WriteLine($"Events in the last 100km: {events}");
            Console.WriteLine();
        }

    }
}
