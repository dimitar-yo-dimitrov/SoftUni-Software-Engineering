using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var persons = new List<Person>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                int age = int.Parse(parts[1]);
                string town = parts[2];

                persons.Add(new Person(name, age, town));
            }

            var indexOfPerson = int.Parse(Console.ReadLine()) - 1;

            int equalCount = 0;
            int notEqualCount = 0;

            foreach (var person in persons)
            {
                if (persons[indexOfPerson].CompareTo(person) == 0)
                {
                    equalCount++;
                }
                else
                {
                    notEqualCount++;
                }
            }

            if (equalCount <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {notEqualCount} {persons.Count}");
            }
        }
    }
}
