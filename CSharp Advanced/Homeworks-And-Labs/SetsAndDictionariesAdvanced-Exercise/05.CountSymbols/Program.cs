using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var chars = new SortedDictionary<char, List<char>>();

            foreach (var symbol in text)
            {
                if (!chars.ContainsKey(symbol))
                {
                    chars.Add(symbol, new List<char>());
                }
                else
                {
                    chars[symbol].Add(symbol);
                }
            }

            foreach (var item in chars)
            {
                // S: 1 time / s
                Console.Write($"{item.Key}: {item.Value.Count + 1} time/s");
                Console.WriteLine();
            }

        }
    }
}
