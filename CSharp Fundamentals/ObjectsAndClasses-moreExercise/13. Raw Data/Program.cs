using System;
using System.Collections.Generic;

namespace _13._Raw_Data
{
    public class Car
    {
        public string Model { get; set; }

        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }

        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = parts[0];
                int engineSpeed = int.Parse(parts[1]);
                int enginePower = int.Parse(parts[2]);
                int cargoWeight = int.Parse(parts[3]);
                string cargoType = parts[4];

                Car car = new Car
                {
                    Model = model,
                    EngineSpeed = engineSpeed,
                    EnginePower = enginePower,
                    CargoWeight = cargoWeight,
                    CargoType = cargoType
                };

                cars.Add(car);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "fragile")
                {
                    foreach (var autoCar in cars)
                    {
                        if (autoCar.CargoType == "fragile" && autoCar.CargoWeight < 1000)
                        {
                            Console.WriteLine(autoCar.Model);
                        }
                    }

                    break;
                }

                else
                {
                    foreach (var autoCar in cars)
                    {
                        if (autoCar.CargoType == "flamable" && autoCar.EnginePower > 250)
                        {
                            Console.WriteLine(autoCar.Model);
                        }
                    }

                    break;
                }
            }
        }
    }
}
