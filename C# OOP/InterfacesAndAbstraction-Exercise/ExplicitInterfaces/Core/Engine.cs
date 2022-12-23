using System;
using System.Collections.Generic;
using System.Linq;
using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces
{
    public class Engine
    {
        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var inputInfo = input.Split();

                var name = inputInfo[0];
                var country = inputInfo[1];
                var age = int.Parse(inputInfo[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                person.GetName();
                resident.GetName();

                input = Console.ReadLine();
            }
        }
    }
}