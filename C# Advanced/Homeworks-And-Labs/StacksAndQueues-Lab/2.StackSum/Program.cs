using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(); 

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Push(input[i]);
            }

            while (true)
            {
                string line = Console.ReadLine().ToLower();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0].ToLower();

                if (command == "add")
                {
                    int numA = int.Parse(parts[1]);
                    int numB = int.Parse(parts[2]);

                    numbers.Push(numA);
                    numbers.Push(numB);
                }

                else if (command == "remove")
                {
                    int countOfRemove = int.Parse(parts[1]);

                    if (numbers.Count <= countOfRemove)
                    {
                        continue;
                    }

                    for (int i = 0; i < countOfRemove; i++)
                    {
                        numbers.Pop();
                    }
                }
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
