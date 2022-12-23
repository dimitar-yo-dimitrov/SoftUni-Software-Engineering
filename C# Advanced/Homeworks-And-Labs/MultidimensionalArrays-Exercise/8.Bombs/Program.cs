using System;
using System.Linq;
using System.Net;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] cellsCoordinates = coordinates[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = cellsCoordinates[0];
                int col = cellsCoordinates[1];

                if (matrix[row, col] > 0)
                {
                    matrix = BobExplode(row, col, matrix, size);
                }
            }

            int aliveCells = 0;
            int sumOfCells = 0;

            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    sumOfCells += item;
                    aliveCells++;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static int[,] BobExplode(int row, int col, int[,] matrix, int size)
        {
            int[,] newMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            int bombPower = newMatrix[row, col];

            if (bombPower > 0)
            {
                newMatrix[row, col] -= bombPower;

                if (row - 1 >= 0 && newMatrix[row - 1, col] > 0) //up
                {
                    newMatrix[row - 1, col] -= bombPower;
                }

                if (row - 1 >= 0 && col - 1 >= 0 && newMatrix[row - 1, col - 1] > 0) //up left
                {
                    newMatrix[row - 1, col - 1] -= bombPower;
                }

                if (row - 1 >= 0 && col + 1 < size && newMatrix[row - 1, col + 1] > 0) //up right
                {
                    newMatrix[row - 1, col + 1] -= bombPower;
                }

                if (row + 1 < size && newMatrix[row + 1, col] > 0) //down
                {
                    newMatrix[row + 1, col] -= bombPower;
                }

                if (row + 1 < size && col - 1 >= 0 && newMatrix[row + 1, col - 1] > 0) //down left
                {
                    newMatrix[row + 1, col - 1] -= bombPower;
                }

                if (row + 1 < size && col + 1 < size && newMatrix[row + 1, col + 1] > 0) //down right
                {
                    newMatrix[row + 1, col + 1] -= bombPower;
                }

                if (col - 1 >= 0 && newMatrix[row, col - 1] > 0) //left
                {
                    newMatrix[row, col - 1] -= bombPower;
                }

                if (col + 1 < size && newMatrix[row, col + 1] > 0) //right
                {
                    newMatrix[row, col + 1] -= bombPower;
                }
            }

            return newMatrix;
        }
    }
}
