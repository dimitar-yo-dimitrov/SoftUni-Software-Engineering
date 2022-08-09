using System;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double avg = numbers.Average();

            int[] result = numbers
                .Where(n => n > avg)
                .OrderByDescending(n => n)
                .Take(5)
                .ToArray();

            if (result.Length == 0)
            {
                Console.WriteLine("No");
            }

            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
