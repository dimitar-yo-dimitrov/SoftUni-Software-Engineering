using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            while (true)
            {
                string tiresInfo = Console.ReadLine();

                if (tiresInfo == "No more tires")
                {
                    break;
                }

                double[] dataForTires = tiresInfo
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Tire[] currentTire = new Tire[4]
                {
                    new Tire((int)dataForTires[0], dataForTires[1]),
                    new Tire((int)dataForTires[2], dataForTires[3]),
                    new Tire((int)dataForTires[4], dataForTires[5]),
                    new Tire((int)dataForTires[6], dataForTires[7])
                };

                tires.Add(currentTire);
            }

            //331 2.2
            //145 2.0
            //Engines done

            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string engineInfo = Console.ReadLine();

                if (engineInfo == "Engines done")
                {
                    break;
                }

                string[] parts = engineInfo
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(parts[0]);
                double cubicCapacity = double.Parse(parts[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                //engine.HorsePower = horsePower;
                //engine.CubicCapacity = cubicCapacity;

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            while (true)
            {
                string carsInfo = Console.ReadLine();

                if (carsInfo == "Show special")
                {
                    break;
                }

                string[] parts = carsInfo
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //{ make}{ model}{ year}{ fuelQuantity}{ fuelConsumption}{ engineIndex}{ tiresIndex}

                string make = parts[0];
                string model = parts[1];
                int year = int.Parse(parts[2]);
                double fuelQuantity = double.Parse(parts[3]);
                double fuelConsumption = double.Parse(parts[4]);
                int engineIndex = int.Parse(parts[5]);
                int tiresIndex = int.Parse(parts[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }

            List<Car> filteredCars = cars
                .Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330)
                .Where(c => c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();

            foreach (var car in filteredCars)
            {
                car.Drive(20);
                Console.WriteLine(car.CarInfo());
            }
        }
    }
}
