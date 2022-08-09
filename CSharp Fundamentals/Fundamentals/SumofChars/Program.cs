using System;

namespace _4.SumofChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < num; i++)
            {
                char input = char.Parse(Console.ReadLine());

                sum += input;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}

