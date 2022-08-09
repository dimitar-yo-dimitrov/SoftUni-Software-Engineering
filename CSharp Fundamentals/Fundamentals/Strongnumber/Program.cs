using System;

namespace _06.Strongnumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int originNumber = number;

            int sum = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;

                int factorial = 1;

                for (int i = 1; i <= lastDigit; i++)
                {
                    factorial *= i;
                }

                sum += factorial;

                number /= 10;


            }

            if (originNumber == sum)
            {
                Console.WriteLine("yes");
            }

            else if (originNumber != sum)
            {
                Console.WriteLine("no");
            }
        }
    }
}
