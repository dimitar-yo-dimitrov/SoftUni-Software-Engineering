using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = byte.Parse(Console.ReadLine());

            int counTarget = 0;
            int originN = n;

            while (n >= m)
            {
               
                n -= m;

                counTarget++;

                if (n == originN / 2 && y > 0)
                {
                    n /= y;
                }

            }

            Console.WriteLine(n);
            Console.WriteLine(counTarget);
        }
    }
}
