using System;
using System.Collections.Generic;
using System.Linq;
using BorderControl.Contracts;
using BorderControl.Models;

namespace BorderControl
{
    public class Engine
    {
        private readonly List<IIdentifiable> identifiables;

        public Engine()
        {
            this.identifiables = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] parts = input.Split();

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];

                    Citizen citizen = new Citizen(name, age, id);

                    this.identifiables.Add(citizen);
                }

                else if (parts.Length == 2)
                {
                    string model = parts[0];
                    string id = parts[1];

                    Robot robot = new Robot(model, id);

                    this.identifiables.Add(robot);
                }

                input = Console.ReadLine();
            }

            string endFakeId = Console.ReadLine();

            foreach (var identifiable in identifiables.Where(x => x.Id.EndsWith(endFakeId)))
            {
                Console.WriteLine(identifiable);
            }
        }
    }
}