using System;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
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

                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = parts[0];
                string model = parts[1];
                string color = parts[2];
                int horsepower = int.Parse(parts[3]);

                Vehicle vehicle = new Vehicle()
                {
                    Type = type,
                    Model = model,
                    Color = color,
                    Horsepower = horsepower
                };

                vehicles.Add(vehicle);

               
            }

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "Close the Catalogue")
                {
                    break;
                }

                Vehicle vehicle = GetVehicleByModel(vehicles, comand);

                if (vehicle == null)
                {
                    continue;
                }
                
                if (vehicle.Type == "car")
                {
                    Console.WriteLine($"Type: Car");
                }
                else
                {
                    Console.WriteLine($"Type: Truck");
                }

                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
            }

            double averagePowerCars = CalcCarHorsePower(vehicles, "car");
            double averagePowerTruck = CalcCarHorsePower(vehicles, "truck");
           
            Console.WriteLine($"Cars have average horsepower of: {averagePowerCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averagePowerTruck:f2}.");
        }

        private static double CalcCarHorsePower(List<Vehicle> vehicles, string type)
        {
            int typeCount = 0;
            int totalHorsePower = 0;

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Type == type)
                {
                    typeCount++;
                    totalHorsePower += vehicle.Horsepower;
                }
            }

            if (typeCount == 0)
            {
                return 0;
            }

            return (double)totalHorsePower / typeCount;
        }


        private static Vehicle GetVehicleByModel(List<Vehicle> vehicles, string comand)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Model == comand)
                {
                    return vehicle;
                }
            }

            return null;
        }
    }
}
