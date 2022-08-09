using System;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            double result = 0;

            foreach (string word in words)
            {
                //A12b
                char firstLetter = word[0];
                char lastLetter = word[word.Length - 1];
                double number = int.Parse(word.Substring(1, word.Length - 2));
              
                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetter - 64;
                }
                else
                {
                    number *= firstLetter - 96;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetter - 64;
                }
                else
                {
                    number += lastLetter - 96;
                }

                result += number * 1.0;
            }

            Console.WriteLine($"{result:F2}");
        }
    }
}
