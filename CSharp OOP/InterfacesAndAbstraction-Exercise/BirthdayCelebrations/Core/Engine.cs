using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayCelebrations.Models;
using BorderControl.Contracts;
using BorderControl.Models;

namespace BorderControl
{
    public class Engine
    {
        private readonly List<IIdentifiable> identifiablesByBirthdate;

        public Engine()
        {
            this.identifiablesByBirthdate = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] parts = input.Split();

                string command = parts[0];

                if (parts.Length == 5)
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    this.identifiablesByBirthdate.Add(citizen);
                }

                else if (parts.Length == 3 && command == "Pet")
                {
                    string name = parts[1];
                    string birthdate = parts[2];

                    Pet pet = new Pet(name, birthdate);

                    this.identifiablesByBirthdate.Add(pet);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            if (identifiablesByBirthdate.Any(x => x.Birthdate.EndsWith(year)))
            {
                foreach (var birthdate in identifiablesByBirthdate.Where(x => x.Birthdate.EndsWith(year)))
                {
                    Console.WriteLine(birthdate);
                }
            }
        }
    }
}