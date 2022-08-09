using System;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles
{
    public class Engine
    {
        private const double AirConditionersConsumption = 1.4;

        public void Run()
        {
            var carInfo = Console.ReadLine().Split();
            
            var fuelQuantityInCar = double.Parse(carInfo[1]);
            var fuelConsumptionInCar = double.Parse(carInfo[2]);
            var tankCapacityInCar = double.Parse(carInfo[3]);
           
            var truckInfo = Console.ReadLine().Split();

            var fuelQuantityInTruck = double.Parse(truckInfo[1]);
            var fuelConsumptionInTruck = double.Parse(truckInfo[2]);
            var tankCapacityInTruck = double.Parse(truckInfo[3]);

            var busInfo = Console.ReadLine().Split();

            var fuelQuantityInBus = double.Parse(busInfo[1]);
            var fuelConsumptionInBus = double.Parse(busInfo[2]);
            var tankCapacityInBus = double.Parse(busInfo[3]);

            IVehicle car = new Car
                (fuelQuantityInCar, fuelConsumptionInCar, tankCapacityInCar);
            
            IVehicle truck = new Truck
                (fuelQuantityInTruck, fuelConsumptionInTruck, tankCapacityInTruck);
           
            IVehicle bus = new Bus
                (fuelQuantityInBus, fuelConsumptionInBus, tankCapacityInBus);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "Drive" when command[1] == "Car":
                    {
                        var distance = double.Parse(command[2]);

                        car.Drive(distance);
                        break;
                    }
                    
                    case "Drive" when command[1] == "Truck":
                    {
                        var distance = double.Parse(command[2]);

                        if (command[1] == "Truck")
                        {
                            truck.Drive(distance);
                        }

                        break;
                    }
                   
                    case "DriveEmpty":
                    {
                        var distance = double.Parse(command[2]);

                        bus.FuelConsumption -= AirConditionersConsumption;

                        if (command[1] == "Bus")
                        {
                            bus.Drive(distance);
                        }

                        break;
                    }

                    case "Drive":
                    {
                        var distance = double.Parse(command[2]);

                        if (command[1] == "Bus")
                        {
                            bus.Drive(distance);
                        }

                        break;
                    }

                    case "Refuel" when command[1] == "Car":
                    {
                        var liters = double.Parse(command[2]);

                        car.Refuel(liters);
                        break;
                    }

                    case "Refuel" when command[1] == "Truck":
                    {
                        var liters = double.Parse(command[2]);

                        truck.Refuel(liters);
                        break;
                    }

                    case "Refuel":
                    {
                        var liters = double.Parse(command[2]);

                        if (command[1] == "Bus")
                        {
                            bus.Refuel(liters);
                        }

                        break;
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}