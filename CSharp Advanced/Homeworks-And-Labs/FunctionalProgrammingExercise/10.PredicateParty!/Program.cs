using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Party!")
                {
                    break;
                }

                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string criteria = parts[1];
                string param = parts[2];

                if (command == "Double")
                {
                    Func<string, bool> filteFunc = GetFilter(criteria, param);
                    var filteredNames = names.Where(filteFunc).ToList();
                    names.InsertRange(0, filteredNames);
                }

                else if (command == "Remove")
                {
                    Predicate<string> predicate = GetPredicate(criteria, param);
                    names.RemoveAll(predicate);
                }
            }

            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Func<string, bool> GetFilter(string criteria, string param)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(param);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(param);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(param);
            }
            else
            {
                return x => true;
            }
        }

        private static Predicate<string> GetPredicate(string criteria, string param)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(param);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(param);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(param);
            }
            else
            {
                return x => true;
            }
        }
    }
}
