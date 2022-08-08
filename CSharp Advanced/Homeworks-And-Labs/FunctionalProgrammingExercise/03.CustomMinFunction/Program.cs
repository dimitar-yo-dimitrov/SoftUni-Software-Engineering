using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<IEnumerable<int>, int> getMinNumber = numbers =>
            {
                int minNumber = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (minNumber > number)
                    {
                        minNumber = number;
                    }
                }

                return minNumber;
            };

            var inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(getMinNumber(inputNumbers));
        }
    }
}
