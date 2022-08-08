using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int[] colSums = new int[matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    colSums[col] += matrix[row, col];
                }
            }

            foreach (var sum in colSums)
            {
                Console.WriteLine(sum);
            }

            /*
             for (int col = 0; col < matrix.GetLength(1); col++)
              {
                  int colSum = 0;
  
                  for (int row = 0; row < matrix.GetLength(0); row++)
                  {
                      colSum += matrix[row, col];
                  }
                 
                  Console.WriteLine(colSum);
              }
            */
        }
    }
}
