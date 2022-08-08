using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            var matrix = new char[rows, cols];

            int playerRow = int.MinValue;
            int playerCol = int.MinValue;

            for (int row = 0; row < rows; row++)
            {
                string fieldRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = fieldRow[col];

                    if (fieldRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
            }

            string directions = Console.ReadLine();

            foreach (var direction in directions)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;

                switch (direction)
                {
                    case 'L': playerCol--; break;
                    case 'R': playerCol++; break;
                    case 'U': playerRow--; break;
                    case 'D': playerRow++; break;
                }

                matrix = SpreadBunnies(matrix, rows, cols);

                if (playerRow < 0 || playerRow >= rows ||
                    playerCol < 0 || playerCol >= cols)
                {
                    PrintResult(matrix, oldPlayerRow, oldPlayerCol, "won");
                    break;
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    PrintResult(matrix, playerRow, playerCol, "dead");
                    break;
                }
            }
        }

        private static char[,] SpreadBunnies(char[,] matrix, int rows, int cols)
        {
            var newMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (row - 1 >= 0) //up
                        {
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (row + 1 < rows) //down
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                        if (col - 1 >= 0) //left
                        {
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (col + 1 < cols) //right
                        {
                            newMatrix[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
        }

        private static void PrintResult(char[,] matrix, int playerRow, int playerCol, string outcome)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine($"{outcome}: {playerRow} {playerCol}");
        }
    }
}
