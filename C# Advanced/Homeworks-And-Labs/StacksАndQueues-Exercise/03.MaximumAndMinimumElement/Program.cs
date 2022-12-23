using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] commandParts = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (commandParts[0] == 1)
                {
                    stack.Push(commandParts[1]);
                }

                else if (commandParts[0] == 2)
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }

                else if (commandParts[0] == 3)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(stack.Max());
                    }
                }

                else if (commandParts[0] == 4)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine($"{string.Join(", ", stack)}");
        }
    }
}
