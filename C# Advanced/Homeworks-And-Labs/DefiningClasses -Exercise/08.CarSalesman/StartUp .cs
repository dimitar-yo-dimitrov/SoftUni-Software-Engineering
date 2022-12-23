using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Engine> engines = new HashSet<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // {model} {power} {displacement} {efficiency}

                string model = engineData[0];
                int power = int.Parse(engineData[1]);

                Engine engine = null;

                if (engineData.Length == 4)
                {
                    int displacement = int.Parse(engineData[2]);
                    string efficiency = engineData[3];

                    engine = new Engine(model, power, displacement, efficiency);


                }

                else if (engineData.Length == 3)
                {
                    int displacement;

                    bool isDisplacement = int.TryParse(engineData[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineData[2]);
                    }
                }

                else if (engineData.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                if (engine != null)
                {
                    engines.Add(engine);
                }
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // {model} {engine} {weight} {color}

                string model = carData[0];
                Engine engine = engines.First(x => x.Model == carData[1]);
                Car car = null;

                if (carData.Length == 4)
                {
                    double weight = double.Parse(carData[2]);
                    string color = carData[3];

                    car = new Car(model, engine, weight, color);


                }

                else if (carData.Length == 3)
                {
                    double weight;

                    bool isWeight = double.TryParse(carData[2], out weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carData[2]);
                    }
                }

                else if (carData.Length == 2)
                {
                    car = new Car(model, engine);
                }

                if (car != null)
                {
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
