using System;
using System.Collections.Generic;

namespace _05.FilterByAgeWithClass
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string[] parts = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                int age = int.Parse(parts[1]);

                Person person = new Person();
                person.Name = name;
                person.Age = age;

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int limitAge = int.Parse(Console.ReadLine());

            Dictionary<string, int> result = new Dictionary<string, int>();

            if (condition == "younger")
            {
                foreach (var person in people)
                {
                    if (person.Age < limitAge)
                    {
                        result.Add(person.Name, person.Age);
                    }
                }
            }

            else if (condition == "older")
            {
                foreach (var person in people)
                {
                    if (person.Age >= limitAge)
                    {
                        result.Add(person.Name, person.Age);
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


