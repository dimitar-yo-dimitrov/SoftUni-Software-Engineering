using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split();
                string comand = parts[0];

                if (comand == "Add")
                {
                    int element = int.Parse(parts[1]);
                    numbers.Add(element);
                }
               
                else if (comand == "Insert")
                {
                    int element = int.Parse(parts[1]);
                    int idx = int.Parse(parts[2]);

                    if (!IsValid(idx, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(idx, element );
                }

                else if (comand == "Remove")
                {
                    int idx = int.Parse(parts[1]);

                    if (!IsValid(idx, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(idx);
                }

                else if (comand == "Shift")
                {
                    string direction = parts[1];
                    int count = int.Parse(parts[2]);
                   
                    if (direction == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstNumber = numbers[0];

                            numbers.RemoveAt(0);
                            numbers.Add(firstNumber);
                        }
                    }

                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastNumber = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastNumber);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static bool IsValid(int idx, List<int> numbers)
        {
            return idx >= 0 && idx < numbers.Count;
        }
    }
}
