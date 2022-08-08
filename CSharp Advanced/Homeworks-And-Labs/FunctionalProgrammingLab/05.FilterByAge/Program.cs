using System;
using System.Collections.Generic;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string[] parts = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                int age = int.Parse(parts[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, age);
                }
            }

            string condition = Console.ReadLine();
            int limitAge = int.Parse(Console.ReadLine());

            Dictionary<string, int> result = new Dictionary<string, int>();

            if (condition == "younger")
            {
                foreach (var person in people)
                {
                    if (person.Value < limitAge)
                    {
                        result.Add(person.Key, person.Value);
                    }
                }
            }

            else if (condition == "older")
            {
                foreach (var person in people)
                {
                    if (person.Value >= limitAge)
                    {
                        result.Add(person.Key, person.Value);
                    }
                }
            }

            string format = Console.ReadLine();

            if (format == "name")
            {
                foreach (var kvp in result)
                {
                    Console.WriteLine(kvp.Key);
                }
            }

            else if (format == "age")
            {
                foreach (var kvp in result)
                {
                    Console.WriteLine(kvp.Value);
                }
            }

            else if (format == "name age")
            {
                foreach (var kvp in result)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
