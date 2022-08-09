using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> time = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double sumOfLeftRacer = 0;
            double sumOfRightRacer = 0;

            for (int i = 0; i < time.Count / 2; i++)
            {
                sumOfLeftRacer += time[i];

                if (time[i] == 0)
                {
                    sumOfLeftRacer *= 0.8;
                }
            }

            time.Reverse();

            for (int j = 0; j < time.Count / 2; j++)
            {
                sumOfRightRacer += time[j];

                if (time[j] == 0)
                {
                    sumOfRightRacer *= 0.80;
                }
            }

            if (sumOfLeftRacer < sumOfRightRacer)
            {
                Console.WriteLine($"The winner is left with total time: {sumOfLeftRacer}");
            }

            else
            {
                Console.WriteLine($"The winner is right with total time: {sumOfRightRacer}");
            }
        }
    }
}
