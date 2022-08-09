using System;
using System.Collections.Generic;
using System.Linq;

namespace problem2
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

                if (line == "END")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string command1 = parts[1];
                string command2 = parts[3];

                if (command == "add")
                {
                    if (command2 == "start")
                    {
                        int a = int.Parse(parts[3]);
                        int b = int.Parse(parts[4]);
                        int c = int.Parse(parts[5]);

                         numbers.Add(a);
                         numbers.Add(b);
                         numbers.Add(c);
                    }
                    else if (command2 == "end")
                    {
                        int a = int.Parse(parts[3]);
                        int b = int.Parse(parts[4]);

                        numbers.Insert(0, b);
                        numbers.Insert(0, a);
                    }

                }
                else if (command == "remove")
                {
                    int value = int.Parse(parts[3]);

                    if (command1 == "lower")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < value)
                            {
                                numbers.Remove(numbers[i]);
                            }
                        }
                    }
                    else if (command1 == "greater")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (value < numbers[i])
                            {
                                numbers.Remove(numbers[i]);
                            }
                        }
                    }
                }
                else if (command == "replace")
                {
                    int value = int.Parse(parts[1]);
                    int newValue = int.Parse(parts[2]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (value == numbers[i])
                        {

                            int index = numbers.IndexOf(value);
                            numbers.Remove(index);
                            numbers.Insert(index, newValue);
                        }
                    }
                }
                else if (command == "remove")
                {
                    if (command2 == "index")
                    {
                        int index = int.Parse(parts[3]);

                        if (numbers.Contains(index))
                        {
                            numbers.Remove(index);
                        }
                    }
                    else if (command1 == "count")
                    {
                        int count = int.Parse(parts[2]);

                        for (int i = numbers.Count - 1; i >= 0; i--)
                        {
                            if (i == numbers.Count - count)
                            {
                               continue; 
                            }

                            numbers.Remove(numbers[i]);
                        }
                    }
                }
                else if (command == "find")
                {
                    if (command1 == "even")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                Console.WriteLine(numbers[i] + " ");
                            }
                        }
                    }
                    else if (command1 == "odd")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 != 0)
                            {
                                Console.WriteLine(numbers[i] + " ");
                            }
                        }
                    }
                }
            
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
