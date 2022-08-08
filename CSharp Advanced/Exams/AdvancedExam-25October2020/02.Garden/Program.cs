using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
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

            int[,] field = new int[rows, cols];

            List<int[]> position = new List<int[]>();

            string commands = Console.ReadLine();

            while (commands != "Bloom Bloom Plow")
            {
                int[] coordinates = commands
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentRow = coordinates[0];
                int currentCol = coordinates[1];

                if (IsValidCoordinates(field, currentRow, currentCol))
                {
                    position.Add(new int[2] { currentRow, currentCol });
                }

                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                commands = Console.ReadLine();
            }

            for (int i = 0; i < position.Count; i++)
            {
                int curRow = position[i][0];
                int curCol = position[i][1];

                field[curRow, curCol]++;

                Bloom(field, curRow, curCol);
            }

            PrintField(field);
        }

        private static void Bloom(int[,] field, int curRow, int curCol)
        {
            for (int row = curRow - 1; row >= 0; row--) // up
            {
                field[row, curCol]++;
            }

            for (int row = curRow + 1; row < field.GetLength(0); row++) // down
            {
                field[row, curCol]++;
            }

            for (int col = curCol - 1; col >= 0; col--) // left
            {
                field[curRow, col]++;
            }

            for (int col = curCol + 1; col < field.GetLength(1); col++) // right
            {
                field[curRow, col]++;
            }
        }

        private static void PrintField(int[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidCoordinates(int[,] field, int currentRow, int currentCol)
        {
            return currentRow >= 0 && currentRow < field.GetLength(0) &&
                   currentCol >= 0 && currentCol < field.GetLength(1);
        }
    }
}
