using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }

            foreach (var divider in dividers)
            {
                Func<int, bool> divisibleNumbers = x => x % divider == 0;

                numbers = numbers.Where(divisibleNumbers).ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
