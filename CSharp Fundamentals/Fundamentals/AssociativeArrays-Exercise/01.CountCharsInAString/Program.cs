using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (var letter in text)
            {
                if (letter == ' ')
                {
                    continue;
                }

                if (!counts.ContainsKey(letter))
                {
                    counts.Add(letter, 1);
                }

                else
                {
                    counts[letter]++;
                }
            }

            foreach (var count in counts)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}
