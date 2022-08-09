using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Program
    {
        public class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }
        public class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            bool isValidCars = true;
            bool isValidTrucks = true;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);

                string type = parts[0];
                string brand = parts[1];
                string model = parts[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(parts[3]);

                    Car car = new Car();

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;

                    cars.Add(car);
                }

                else
                {
                    int weight = int.Parse(parts[3]);

                    Truck truck = new Truck();

                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;

                    trucks.Add(truck);
                }
            }



            foreach (Car car in cars.OrderBy(x => x.Brand))
            {
                if (isValidCars)
                {
                    Console.WriteLine("Cars:");
                    isValidCars = false;
                }

                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            foreach (Truck truck in trucks.OrderBy(x => x.Brand))
            {
                if (isValidTrucks)
                {
                    Console.WriteLine("Trucks:");
                    isValidTrucks = false;
                }

                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}
