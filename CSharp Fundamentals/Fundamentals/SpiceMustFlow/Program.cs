using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 100)
            {
                Console.WriteLine(0);
                Console.WriteLine(0);

                return;
            }

            long totalSpise = 0;
            int days = 0;

            while (number >= 100)
            {
                days++;

                totalSpise += number - 26;

                number -= 10;

            }

            totalSpise -= 26; 
           
            Console.WriteLine(days);
            Console.WriteLine(totalSpise);
        }
    }
}
