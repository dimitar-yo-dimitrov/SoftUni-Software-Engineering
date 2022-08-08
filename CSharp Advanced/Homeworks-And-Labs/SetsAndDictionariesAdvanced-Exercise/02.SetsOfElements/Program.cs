using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = size[0];
            int m = size[1];

            HashSet<int> firstSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                firstSet.Add(inputNumber);
            }

            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < m; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                secondSet.Add(inputNumber);
            }

            List<int> resultSet = firstSet.Intersect(secondSet).ToList();

            Console.WriteLine(string.Join(" ", resultSet));
        }
    }
}
