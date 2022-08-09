using System;
using System.Collections.Generic;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var forceUsers = new Dictionary<string, string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Lumpawaroo")
                {
                    break;
                }

                string[] parts = new string[0];

                if (line.Contains(" | "))
                {
                    parts = line
                       .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = parts[0];
                    string forceUser = parts[1];

                    if (!forceUsers.ContainsKey(forceUser))
                    {
                        forceUsers.Add(forceUser, forceSide );
                    }
                }

                else if (line.Contains(" -> "))
                {
                    parts = line
                       .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string forceUser = parts[0];
                    string forceSide = parts[1];

                    if (forceUsers.ContainsKey(forceUser))
                    {
                        forceUsers[forceUser] = forceSide;
                    }

                    else
                    {
                        
                    }
                }
            }
        }
    }
}
