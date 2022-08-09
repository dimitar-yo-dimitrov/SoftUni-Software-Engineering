using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FoldAndSum
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstNumbers = new List<int>();
            var secondNumbers = new List<int>();

            var firstPart = numbers.Take(numbers.Length / 2).ToArray();
            var secondPart = numbers.Skip(numbers.Length / 2).ToArray();

            for (int i = 0; i < firstPart.Length / 2; i++)
            {
                firstNumbers.Add(firstPart[i] + firstPart[firstPart.Length - 1 - i]);
            }

            for (int i = 0; i < secondPart.Length / 2; i++)
            {
                secondNumbers.Add(secondPart[i] + secondPart[secondPart.Length - 1 - i]);
            }

            firstNumbers.Reverse();

            var result = firstNumbers.Concat(secondNumbers);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
