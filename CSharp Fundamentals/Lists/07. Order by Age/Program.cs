using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    public class People
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int AgeOfPerson { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                string iD = parts[1];
                int ageOfPerson = int.Parse(parts[2]);

                People people = new People()
                {
                    Name = name,
                    ID = iD,
                    AgeOfPerson = ageOfPerson
                };

                peoples.Add(people);
            }

            List<People> sorted = peoples
                .OrderBy(p => p.AgeOfPerson)
                .ToList();

            foreach (var people in sorted)
            {
                Console.WriteLine($"{people.Name} with ID: {people.ID} is {people.AgeOfPerson} years old.");
            }
        }
    }
}
