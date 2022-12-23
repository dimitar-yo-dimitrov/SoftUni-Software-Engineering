using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.TheV_LoggerWithClass
{
   

    class Program
    {
        static void Main(string[] args)
        {
            var vlogger = new Dictionary<string, Vlogger>();

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
                    vlogger.Add(firstVlogger, new Vlogger());
                }

                else if (command == "followed" &&
                         vlogger.ContainsKey(firstVlogger) &&
                         vlogger.ContainsKey(secondVlogger) &&
                         firstVlogger != secondVlogger)
                {
                    vlogger[firstVlogger].Following.Add(secondVlogger);
                    vlogger[secondVlogger].Followers.Add(firstVlogger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

            int number = 1;

            var sorted = vlogger
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count);

            /*
              1.VenomTheDoctor : 2 followers, 0 following
                 * EmilConrad
                 *Saffrona
            */

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{number}. {kvp.Key} : {kvp.Value.Followers.Count} followers, {kvp.Value.Following.Count} following");

                if (number == 1)
                {
                    foreach (var name in kvp.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }

                number++;
            }
        }
    }
}
