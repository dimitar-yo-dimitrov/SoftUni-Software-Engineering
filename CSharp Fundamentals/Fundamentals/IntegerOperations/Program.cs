using System;

namespace _01.IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNumber = int.Parse(Console.ReadLine());
            long secondNumber = int.Parse(Console.ReadLine());
            long thirdNumber = int.Parse(Console.ReadLine());
            long fourthNumber = int.Parse(Console.ReadLine());

            long sum = ((firstNumber + secondNumber) / thirdNumber) * fourthNumber;

            Console.WriteLine(sum);
        }
    }
}
