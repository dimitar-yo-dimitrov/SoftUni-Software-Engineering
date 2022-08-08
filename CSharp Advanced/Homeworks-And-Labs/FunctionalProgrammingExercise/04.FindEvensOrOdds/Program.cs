using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> predicate = n => true;

            string command = Console.ReadLine();

            if (command == "odd")
            {
                predicate = n => n % 2 != 0;
            }

            else if (command == "even")
            {
                predicate = n => n % 2 == 0;
            }

            var result = GetIvenOrOdd(numbers, predicate);

            Console.WriteLine(string.Join(" ", result));
        }

        private static Queue<int> GetIvenOrOdd(List<int> numbers, Predicate<int> predicate)
        {
            var newNumbers = new Queue<int>();

            foreach (var number in numbers)
            {
                if (predicate(number))
                {
                    newNumbers.Enqueue(number);
                }
            }

            return newNumbers;
        }
    }
}
