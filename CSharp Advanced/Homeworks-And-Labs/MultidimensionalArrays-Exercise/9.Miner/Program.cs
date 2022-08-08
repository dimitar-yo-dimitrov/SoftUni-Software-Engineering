using System;
using System.Data;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var matrix = new string[n, n];

            int currentRow = 0;
            int currentCol = 0;
            int coalCounter = 0;

            for (int row = 0; row < n; row++)
            {
                var fieldRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = fieldRow[col];

                    if (matrix[row, col] == "s")
                    {
                        currentRow = row;
                        currentCol = col;
                        matrix[row, col] = "*";
                    }

                    if (matrix[row, col] == "c")
                    {
                        coalCounter++;
                    }
                }
            }

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "up":
                        if (currentRow - 1 >= 0)
                        {
                            currentRow--;
                        }
                        break;

                    case "down":
                        if (currentRow + 1 < n)
                        {
                            currentRow++;
                        }
                        break;

                    case "left":
                        if (currentCol - 1 >= 0)
                        {
                            currentCol--;
                        }
                        break;

                    case "right":
                        if (currentCol + 1 < n)
                        {
                            currentCol++;
                        }
                        break;
                }

                if (matrix[currentRow, currentCol] == "c")
                {
                    coalCounter--;
                    matrix[currentRow, currentCol] = "*";

                    if (coalCounter == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        Environment.Exit(0);
                    }
                }

                if (matrix[currentRow, currentCol] == "e")
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine($"{coalCounter} coals left. ({currentRow}, {currentCol})");
        }
    }
}
