using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int countOfCars = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        countOfCars++;
                    }

                    continue;
                }

                cars.Enqueue(input);
            }

            Console.WriteLine($"{countOfCars} cars passed the crossroads.");
        }
    }
}
