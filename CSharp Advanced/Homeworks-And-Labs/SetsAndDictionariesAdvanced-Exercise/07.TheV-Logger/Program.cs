using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vlogger = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Statistics")
                {
                    break;
                }

                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                /*
                 Saffrona joined The V-Logger
                 Saffrona followed EmilConrad 
                */

                string command = parts[1];
                string firstVlogger = parts[0];
                string secondVlogger = parts[2];

                if (command == "joined" && !vlogger.ContainsKey(firstVlogger))
                {
                    vlogger.Add(firstVlogger, new Dictionary<string, HashSet<string>>());
                    vlogger[firstVlogger].Add("followers", new HashSet<string>());
                    vlogger[firstVlogger].Add("following", new HashSet<string>());
                }

                else if (command == "followed" &&
                         vlogger.ContainsKey(firstVlogger) &&
                         vlogger.ContainsKey(secondVlogger) &&
                         firstVlogger != secondVlogger)
                {
                    vlogger[firstVlogger]["following"].Add(secondVlogger);
                    vlogger[secondVlogger]["followers"].Add(firstVlogger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

            int number = 1;

            var sorted = vlogger
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count);

            /*
              1.VenomTheDoctor : 2 followers, 0 following
                 * EmilConrad
                 *Saffrona
            */

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{number}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");

                if (number == 1)
                {
                    foreach (var name in kvp.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }

                number++;
            }
        }
    }
}
