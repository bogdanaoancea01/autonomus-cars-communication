using autonomus_cars.DTOs;
using autonomus_cars.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace autonomus_cars.Services
{
    public interface ICarService
    {
        void AddCarOnRoad(Car car);
        double DistanceBetweenCars(Car carA, Car carB);
        Car ClosestCar(Car sourceCar);
        public void SendData(Car from, Car to);
        public void ReceiveData(Car receiver, CarDTO receivedData);
    }
}
