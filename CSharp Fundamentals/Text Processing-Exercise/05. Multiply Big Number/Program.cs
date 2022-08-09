using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());




            Console.WriteLine(MultiplyBigNumbers(multiplier, number));
        }

        private static string MultiplyBigNumbers(int multiplier, string number)
        {
            if (multiplier == 0)
            {
                return "0";
            }
            int remainder = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i] - '0';

                remainder += multiplier * digit;

                if (remainder > 9)
                {
                    int remainderLastDigit = remainder % 10;
                    remainder /= 10;

                    sb.Append(remainderLastDigit.ToString());
                }
                else
                {
                    sb.Append(remainder.ToString());
                    remainder = 0;
                }
            }

            if (remainder > 0)
            {
                sb.Append(remainder.ToString());
            }

            return string.Concat(sb.ToString().Reverse());
        }
    }
}
