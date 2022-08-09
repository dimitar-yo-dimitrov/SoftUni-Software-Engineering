using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split();
                string comand = parts[0];

                if (comand == "Delete")
                {
                    int element = int.Parse(parts[1]);

                    numbers.RemoveAll(n => n == element);
                }

                else
                {
                    int element = int.Parse(parts[1]);
                    int count = int.Parse(parts[2]);

                    numbers.Insert(count, element);
                }
            }

            Console.Write(string.Join(" ", numbers));
        }
    }
}
