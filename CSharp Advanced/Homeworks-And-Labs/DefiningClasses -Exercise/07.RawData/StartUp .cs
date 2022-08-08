using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] infoCar = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // {model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}
                // {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                string model = infoCar[0];
                int engineSpeed = int.Parse(infoCar[1]);
                int enginePower = int.Parse(infoCar[2]);
                int cargoWeight = int.Parse(infoCar[3]);
                string cargoType = infoCar[4];

                List<Tire> tires = new List<Tire>();

                for (int tireIndex = 5; tireIndex <= 12; tireIndex += 2)
                {
                    double tirePressure = double.Parse(infoCar[tireIndex]);
                    int tireAge = int.Parse(infoCar[tireIndex + 1]);

                    Tire tire = new Tire(tirePressure, tireAge);
                    tires.Add(tire);
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                // print all cars whose cargo is "fragile" with a tire, whose pressure is  < 1

                List<Car> fragileCars = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(t => t.Pressure < 1))
                    .ToList();

                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                // print all of the cars, whose cargo is "flammable" and have engine power > 250

                List<Car> flammableCars = cars
                    .Where(x => x.Cargo.CargoType == "flammable" && x.Engine.Power > 250)
                    .ToList();

                foreach (var car in flammableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
