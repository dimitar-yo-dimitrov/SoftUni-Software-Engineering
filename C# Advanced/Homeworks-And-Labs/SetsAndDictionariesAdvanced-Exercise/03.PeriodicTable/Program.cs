using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] elements = new string[rows][];

            SortedSet<string> chemicalElements = new SortedSet<string>();

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                elements[row] = new string[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    chemicalElements.Add(currentRow[col]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}
