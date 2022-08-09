using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    public class Person
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person
                {
                    Name = parts[0],
                    ID = parts[1],
                    Age = int.Parse(parts[2])
                };

                persons.Add(person);
            }       

            var sorted = persons
                .OrderBy(a => a.Age);

            foreach (var person in sorted)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}
