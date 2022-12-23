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
                string[] dataCar = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // {model} {fuelAmount} {fuelConsumptionFor1km}
                //  AudiA4     23            0.3

                string model = dataCar[0];
                double fuelAmount = double.Parse(dataCar[1]);
                double fuelConsumptionFor1km = double.Parse(dataCar[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

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
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // Drive { carModel} { amountOfKm}

                string command = parts[0];
                string carModel = parts[1];
                double distance = double.Parse(parts[2]);

                if (command == "Drive")
                {
                    var car = cars
                        .Where(x => x.Model == carModel)
                        .FirstOrDefault();

                    car.Drive(distance);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
