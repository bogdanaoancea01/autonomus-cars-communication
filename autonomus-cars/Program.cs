using autonomus_cars;
using autonomus_cars.Models;
using autonomus_cars.Services;

class Program
{
    static void Main(string[] args)
    {
        ICarService carService = new CarService();

        //initialize cars
        Car c1 = new Car("Audi", "A5");
        Car c2 = new Car("Seat", "Ibiza");
        Car c3 = new Car("BMW", "X7");
        Car c4 = new Car("Tesla", "Model S");
        Car c5 = new Car("Dacia", "Duster");
        Car c6 = new Car("Skoda", "Fabia");

        c1.SetLocation(new Location(0, 0));
        c2.SetLocation(new Location(10, 10));
        c3.SetLocation(new Location(500, 500));
        c4.SetLocation(new Location(2, 1));
        
        c1.SetSpeed(100);
        c2.SetSpeed(120);
        c4.SetSpeed(90);

        //add cars on road
        carService.AddCarOnRoad(c1);
        carService.AddCarOnRoad(c2);
        carService.AddCarOnRoad(c3);
        carService.AddCarOnRoad(c4);
        carService.AddCarOnRoad(c5);
        carService.AddCarOnRoad(c6);

        carService.AddCarOnRoad(c3);

        Console.WriteLine();

        // handle car events
        c1.AddEvent("Accident detected");
        c1.AddEvent("Heavy snow");
        c1.AddEvent("Icy road");
        c2.AddEvent("Slippery road");
        c4.AddEvent("Heavy rain");

        Console.Write($"Events in {c1.Manufacturer}-{c1.Model}: ");
        Console.WriteLine(string.Join(", ", c1.CarEvents.Select(e => e.EventDescription)));

        Console.Write($"Events in {c2.Manufacturer}-{c2.Model}: ");
        Console.WriteLine(string.Join(", ", c2.CarEvents.Select(e => e.EventDescription)));
        Console.WriteLine();

        Console.WriteLine($"Car {c1.Manufacturer}-{c1.Model} drives 200km");
        c1.UpdateLocation(new Location(0, 200));
        c1.AddEvent("New accident at km 200");
        Console.WriteLine($"Car {c1.Manufacturer}-{c1.Model} encounters new event");
        c1.UpdateLocation(new Location(0, 280));
        Console.WriteLine($"Car {c1.Manufacturer}-{c1.Model} drives more 80km");
        var eventsC1 = c1.CarEvents.Any()
            ? string.Join(", ", c1.CarEvents.Select(e => e.EventDescription))
            : "No events";
        Console.WriteLine($"Events in the last 100km for {c1.Manufacturer}-{c1.Model}: {eventsC1}");
        Console.WriteLine();


        Console.WriteLine($"Car {c2.Manufacturer}-{c2.Model} drives 100km");
        c2.UpdateLocation(new Location(0, 110));
        var eventsC2 = c2.CarEvents.Any()
            ? string.Join(", ", c2.CarEvents.Select(e => e.EventDescription))
            : "No events";
        Console.WriteLine($"Events in the last 100km for {c2.Manufacturer}-{c2.Model}: {eventsC2}");
        Console.WriteLine();


        // Distances
        Car closestToC4 = carService.ClosestCar(c4);
        Console.WriteLine($"Closest car to {c4.Manufacturer}-{c4.Model} is {closestToC4.Manufacturer}-{closestToC4.Model}");

        Car closestToC5 = carService.ClosestCar(c5);
        Console.WriteLine($"Closest car to {c5.Manufacturer}-{c5.Model} is {closestToC5.Manufacturer}-{closestToC5.Model}");
        Console.WriteLine();

        double distanceC1C2 = carService.DistanceBetweenCars(c1, c2);
        Console.WriteLine($"Distance between {c1.Manufacturer}-{c1.Model} and {c2.Manufacturer}-{c2.Model} is: {distanceC1C2} km");

        double distanceC1C5 = carService.DistanceBetweenCars(c1, c5);
        Console.WriteLine($"Distance between {c1.Manufacturer}-{c1.Model} and {c5.Manufacturer}-{c5.Model} is: {distanceC1C5} km");

        double distanceC5C6 = carService.DistanceBetweenCars(c5, c6);
        Console.WriteLine($"Distance between {c5.Manufacturer}-{c5.Model} and {c6.Manufacturer}-{c6.Model} is: {distanceC5C6} km");
        Console.WriteLine();


        // Send & receive data
        c4.AddEvent("Low tire pressure");
        carService.SendData(c4, closestToC4);

        carService.SendData(c5, c4);

    }
}