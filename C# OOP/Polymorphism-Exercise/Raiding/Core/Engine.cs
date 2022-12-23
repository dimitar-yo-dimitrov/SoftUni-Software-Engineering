using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Models;

namespace Raiding
{
    public class Engine
    {
        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            var heroes = new List<BaseHero>();

            BaseHero hero;

            int counter = 0;

            while (n != counter)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();

                    if (type == "Druid")
                    {
                        hero = new Druid(name);
                    }

                    else if (type == "Paladin")
                    {
                        hero = new Paladin(name);
                    }
                    else if (type == "Rogue")
                    {
                        hero = new Rogue(name);
                    }
                
                    else if (type == "Warrior")
                    {
                        hero = new Warrior(name);
                    }

                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }

                    heroes.Add(hero);
                    counter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var bossPower = long.Parse(Console.ReadLine());

            foreach (var heroType in heroes)
            {
                Console.WriteLine(heroType.CastAbility());
            }

            long heroTotalPower = heroes.Select(x => x.Power).Sum();

            Console.WriteLine(heroTotalPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}