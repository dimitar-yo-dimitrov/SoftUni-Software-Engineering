using System;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int[] arr = new int[count];

            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();

            Console.WriteLine(sum);
        }
    }
}
