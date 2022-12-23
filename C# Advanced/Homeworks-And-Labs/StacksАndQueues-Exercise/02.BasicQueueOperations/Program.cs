using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            int popedNumbers = input[1];
            int checkForExistingElement = input[2];

            for (int i = 0; i < popedNumbers; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(checkForExistingElement))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(queue.Count);
                }
            }
        }
    }
}
