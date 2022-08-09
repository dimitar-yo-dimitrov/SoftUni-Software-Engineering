using System;
using System.Linq;

namespace Arrays._01.train
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            string[] arr = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[] numArr = new int[arr.Length];

            for (int i = 0; i < numArr.Length; i++)
            {
                numArr[i] = int.Parse(arr[i]);
            }
        }
    }
}
