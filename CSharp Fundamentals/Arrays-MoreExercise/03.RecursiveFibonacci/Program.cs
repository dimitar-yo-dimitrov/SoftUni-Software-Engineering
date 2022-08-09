using System;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(FibonacciRecursion(n));
        }

        private static long FibonacciRecursion(int n)
        {
            if (n <= 2) return 1;

            return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
        }
    }
}
