using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] infoPerson = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = infoPerson[0];
                int age = int.Parse(infoPerson[1]);

                Person person = new Person(name, age);

                persons.Add(person);
            }

            var result = persons
                .OrderBy(x => x.Name)
                .Where(x => x.Age > 30);

            foreach (var people in result)
            {
                Console.WriteLine($"{people.Name} - {people.Age}");
            }
        }
    }
}
