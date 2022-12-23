using System;
using System.Collections.Generic;
using System.Linq;
using PersonsInfo;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var firstName = personInfo[0];
                var lastName = personInfo[1];
                var age = int.Parse(personInfo[2]);
                var salary = decimal.Parse(personInfo[3]);

                var person = new Person(firstName, lastName, age, salary);

                persons.Add(person);
            }

            var percentage = decimal.Parse(Console.ReadLine());

            persons.ForEach(p => p.IncreaseSalary(percentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}

