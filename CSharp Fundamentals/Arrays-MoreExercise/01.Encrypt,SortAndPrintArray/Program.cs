using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Encrypt_SortAndPrintArray
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var sum = 0;

            var vowels = new List<char> 
                { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };

            var numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                foreach (var symbol in input)
                {
                    if (vowels.Contains(symbol))
                    {
                            sum += symbol * input.Length;
                    }
                    else
                    {
                            sum += symbol / input.Length;
                    }
                }

                numbers.Add(sum);
                sum = 0;
            }

            foreach (var number in numbers.OrderBy(x => x))
            {
                Console.WriteLine(number);
            }
        }
    }
}
