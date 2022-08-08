using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizes, sizes];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int sumOfPrimaryDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col = row;
                sumOfPrimaryDiagonal += matrix[row, col];
            }

            int sumOfSecondaryDiagonal = 0;
            int currentCol = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                int col = row;
                sumOfSecondaryDiagonal += matrix[row, currentCol];
                currentCol++;
            }

            int difference = Math.Abs(sumOfPrimaryDiagonal - sumOfSecondaryDiagonal);

            Console.WriteLine(difference);
        }
    }
}
