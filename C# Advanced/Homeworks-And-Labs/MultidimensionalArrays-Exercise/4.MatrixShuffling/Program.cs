using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            var matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "swap")
                {
                    if (parts.Length == 5)
                    {
                        int row1 = int.Parse(parts[1]);
                        int col1 = int.Parse(parts[2]);
                        int row2 = int.Parse(parts[3]);
                        int col2 = int.Parse(parts[4]);

                        if (IsValidCell(row1, col1, row2, col2, rows, cols))
                        {
                            string currentElement = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = currentElement;

                            PrintMatrix(matrix);
                        }

                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
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

        private static bool IsValidCell(int row1, int col1, int row2, int col2, int rows, int cols)
        {
            return row1 >= 0 && row1 < rows && row2 >= 0 && row2 < rows &&
                   col1 >= 0 && col1 < cols && col2 >= 0 && col2 < cols ? true : false;
        }
    }
}
