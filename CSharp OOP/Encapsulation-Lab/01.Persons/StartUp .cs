using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var firstName = personInfo[0];
                var lastName = personInfo[1];
                var age = int.Parse(personInfo[2]);

                var person = new Person(firstName, lastName, age);

                persons.Add(person);
            }

            persons.OrderBy(x => x.FirstName)
                .ThenBy(x => x.Age)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
