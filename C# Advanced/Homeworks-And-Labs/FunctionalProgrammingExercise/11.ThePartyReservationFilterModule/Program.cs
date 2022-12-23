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

            var removedNames = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Print")
                {
                    break;
                }

                string[] parts = line
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = parts[0];
                string criteria = parts[1];
                string param = parts[2];

                if (command == "Add filter")
                {
                    Predicate<string> predicate = GetPredicate(criteria, param);
                    
                    removedNames.AddRange(names.Where(x => predicate(x)));
                    names.RemoveAll(predicate);
                  
                }

                else if (command == "Remove filter")
                {
                    Func<string, bool> filteFunc = GetFilter(criteria, param);
                 
                    names.AddRange(removedNames.Where(filteFunc));
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }

        private static Func<string, bool> GetFilter(string criteria, string param)
        {
            if (criteria == "Starts with")
            {
                return x => x.StartsWith(param);
            }
            else if (criteria == "Ends with")
            {
                return x => x.EndsWith(param);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(param);
            }
            else if (criteria == "Contains")
            {
                return x => x.Contains(param);
            }
            else
            {
                return x => true;
            }
        }

        private static Predicate<string> GetPredicate(string criteria, string param)
        {
            if (criteria == "Starts with")
            {
                return x => x.StartsWith(param);
            }
            else if (criteria == "Ends with")
            {
                return x => x.EndsWith(param);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(param);
            }
            else if (criteria == "Contains")
            {
                return x => x.Contains(param);
            }
            else
            {
                return x => true;
            }
        }
    }
}

