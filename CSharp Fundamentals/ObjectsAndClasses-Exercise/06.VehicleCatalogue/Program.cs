using System;
using System.Collections.Generic;

namespace _06.VehicleCatalogue
{
    public class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string typeOfVehicle = parts[0];
                string model = parts[1];
                string color = parts[2];
                int horsepower = int.Parse(parts[3]);

                Vehicle vehicle = new Vehicle
                {
                    Type = typeOfVehicle,
                    Model = model,
                    Color = color,
                    Horsepower = horsepower
                };

                vehicles.Add(vehicle);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Close the Catalogue")
                {
                    break;
                }

                Vehicle vehicle = GetVehicleByModel(vehicles, command);

                if (vehicle == null)
                {
                    continue;
                }

                if (vehicle.Type == "car")
                {
                    Console.WriteLine("Type: Car");
                }

                else
                {
                    Console.WriteLine("Type: Truck");
                }

                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
            }

            double averagePowerCars = CalcHorsePower(vehicles, "car");
            double averagePowerTrucks = CalcHorsePower(vehicles, "truck");

            Console.WriteLine($"Cars have average horsepower of: {averagePowerCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averagePowerTrucks:f2}.");
        }

        private static double CalcHorsePower(List<Vehicle> vehicles, string command)
        {
            int countOfType = 0;
            int totalHoresePower = 0;

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Type == command)
                {
                    countOfType++;
                    totalHoresePower += vehicle.Horsepower;
                }
            }

            if (countOfType == 0)
            {
                return 0;
            }

            return (double)totalHoresePower / countOfType;
        }

        private static Vehicle GetVehicleByModel(List<Vehicle> vehicles, string command)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Model == command)
                {
                    return vehicle;
                }
            }

            return null;
        }
    }
}
