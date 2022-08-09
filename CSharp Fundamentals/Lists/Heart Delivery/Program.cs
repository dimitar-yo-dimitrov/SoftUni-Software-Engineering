using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int currentIdx = 0;

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "Love!")
                {
                    break;
                }

                string[] parts = comand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                currentIdx += int.Parse(parts[1]);

                if (currentIdx >= houses.Length)
                {
                    currentIdx = 0;
                }

                if (houses[currentIdx] == 0)
                {
                    Console.WriteLine($"Place {currentIdx} already had Valentine's day.");
                }

                else
                {
                    houses[currentIdx] -= 2;

                    if (houses[currentIdx] == 0)
                    {
                        Console.WriteLine($"Place {currentIdx} has Valentine's day.");
                    }
                }
            }

            Console.WriteLine($"Cupid's last position was {currentIdx}.");

            int withoutValentinDays = houses
                .Where(h => h > 0)
                .Count();

            if (withoutValentinDays > 0)
            {
                Console.WriteLine($"Cupid has failed {withoutValentinDays} places.");
            }

            else
            {
                Console.WriteLine($"Mission was successful.");
            }
        }
    }
}
