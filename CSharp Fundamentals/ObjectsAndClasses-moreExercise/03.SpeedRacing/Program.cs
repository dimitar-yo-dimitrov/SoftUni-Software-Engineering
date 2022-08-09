using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelPerKm { get; set; }

        public int Distance { get; set; }

        public bool EnoughtFuel(int amountKm)
        {
            bool isEnoughtFuel = false;

            if (this.FuelPerKm * amountKm <= this.FuelAmount)
            {
                isEnoughtFuel = true;
            }

            return isEnoughtFuel;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelPerKm = double.Parse(carData[2]);

                Car car = new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelPerKm = fuelPerKm
                };

                cars.Add(car);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = parts[1];
                int amountOfKm = int.Parse(parts[2]);

                var chosenCar = cars.FirstOrDefault(c => c.Model == carModel);

                if (chosenCar.EnoughtFuel(amountOfKm))
                {
                    chosenCar.FuelAmount -= amountOfKm * chosenCar.FuelPerKm;
                    chosenCar.Distance += amountOfKm;
                }

                else
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }
    }
}
