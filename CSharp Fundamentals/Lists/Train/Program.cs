using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split();

                if (parts.Length == 2)
                {
                    int passengers = int.Parse(parts[1]);

                    wagons.Add(passengers);
                }

                else
                {
                    int passengers = int.Parse(parts[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int curentWagon = wagons[i];

                        if (curentWagon + passengers <= maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
            }

            Console.Write(string.Join(" ", wagons));
        }
    }
}
