using System;
using System.Collections.Generic;

namespace _02._aMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(line))
                {
                    resources[line] += quantity;
                }

                else
                {
                    resources.Add(line, quantity);
                }
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
