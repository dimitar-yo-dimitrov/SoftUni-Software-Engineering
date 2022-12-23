using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                else if (command == "end")
                {
                    break;
                }

                else if (command == "add")
                {
                    numbers = numbers
                        .Select(n => n + 1)
                        .ToList();
                }

                else if (command == "multiply")
                {
                    numbers = numbers
                        .Select(n => n * 2)
                        .ToList();

                }

                else if (command == "subtract")
                {
                    numbers = numbers
                        .Select(n => n - 1)
                        .ToList();
                }
            }
        }
    }
}
