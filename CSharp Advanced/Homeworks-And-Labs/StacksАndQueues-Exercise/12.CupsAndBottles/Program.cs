using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacityArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottlesCapacityArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacityArray);
            Stack<int> bottles = new Stack<int>(bottlesCapacityArray);

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {

                int currentCupValue = cups.Peek();
                int currentBottleValue = bottles.Peek();

                if (currentBottleValue >= currentCupValue)
                {
                    if (currentCupValue - currentBottleValue <= 0)
                    {
                        cups.Dequeue();
                    }

                    wastedWater += currentBottleValue - currentCupValue;
                    bottles.Pop();
                }

                else
                {
                    while (currentCupValue > 0)
                    {
                        currentCupValue -= bottles.Pop(); ;
                    }

                    wastedWater += Math.Abs(currentCupValue);
                    cups.Dequeue();
                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }

            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
