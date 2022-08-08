using System;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int removedKnight = 0;

            while (true)
            {
                int maxAttacks = int.MinValue;
                int knightRow = int.MinValue;
                int knightCol = int.MinValue;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] != 'K')
                        {
                            continue;
                        }

                        else
                        {
                            int currentAttacks = CountAttacks(matrix, row, col);

                            if (maxAttacks < currentAttacks)
                            {
                                maxAttacks = currentAttacks;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    matrix[knightRow, knightCol] = '0';
                    removedKnight++;
                }

                else
                {
                    break;
                }
            }

            Console.WriteLine(removedKnight);
        }

        private static int CountAttacks(char[,] matrix, int row, int col)
        {
            int attacks = 0;

            if (IsValid(row - 2, col + 1, matrix))
            {
                attacks++;
            }

            if (IsValid(row - 1, col + 2, matrix))
            {
                attacks++;
            }

            if (IsValid(row + 1, col + 2, matrix))
            {
                attacks++;
            }

            if (IsValid(row + 2, col + 1, matrix))
            {
                attacks++;
            }

            if (IsValid(row + 2, col - 1, matrix))
            {
                attacks++;
            }

            if (IsValid(row + 1, col - 2, matrix))
            {
                attacks++;
            }

            if (IsValid(row - 1, col - 2, matrix))
            {
                attacks++;
            }

            if (IsValid(row - 2, col - 1, matrix))
            {
                attacks++;
            }

            return attacks;
        }

        private static bool IsValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1) &&
                   matrix[row, col] == 'K';
        }
    }
}
