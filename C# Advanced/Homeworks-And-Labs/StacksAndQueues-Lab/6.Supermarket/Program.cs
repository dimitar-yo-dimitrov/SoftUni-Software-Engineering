using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> peoples = new Queue<string>();

            int count = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                if (line == "Paid")
                {
                    while (peoples.Any())
                    {
                        Console.WriteLine(peoples.Dequeue());
                    }
                }
                else
                {
                    peoples.Enqueue(line);
                }

            }

            Console.WriteLine($"{peoples.Count} people remaining.");
        }
    }
}
