using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal savingsMoney = decimal.Parse(Console.ReadLine());

            List<int> initialDrums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> price = new List<int>();
            price.AddRange(initialDrums);

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Hit it again, Gabsy!")
                {
                    break;
                }

                int hitPower = int.Parse(line);

                for (int i = 0; i < initialDrums.Count; i++)
                {
                    initialDrums[i] -= hitPower;

                    if (initialDrums[i] <= 0)
                    {
                        if (savingsMoney - (price[i] * 3) >= 0)
                        {
                            savingsMoney = savingsMoney - price[i] * 3;
                            initialDrums[i] = price[i];
                        }
                    }
                }

                for (int i = 0; i < initialDrums.Count; i++)
                {
                    if (initialDrums[i] <= 0)
                    {
                        initialDrums.Remove(initialDrums[i]);
                        price.Remove(price[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", initialDrums));
            Console.WriteLine($"Gabsy has {savingsMoney:f2}lv.");
        }
    }
}
