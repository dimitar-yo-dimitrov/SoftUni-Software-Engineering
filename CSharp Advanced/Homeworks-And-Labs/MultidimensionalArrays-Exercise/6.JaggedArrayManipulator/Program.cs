using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = currentRow;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int i = row; i < row + 2; i++)
                    {
                        for (int j = 0; j < jaggedArray[row].Length; j++)
                        {
                            jaggedArray[i][j] *= 2;
                        }
                    }
                }

                else
                {
                    for (int i = row; i < row + 2; i++)
                    {
                        for (int j = 0; j < jaggedArray[i].Length; j++)
                        {
                            jaggedArray[i][j] /= 2;
                        }
                    }
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                int indexRow = int.Parse(parts[1]);
                int indexCol = int.Parse(parts[2]);
                int value = int.Parse(parts[3]);

                if (!(indexRow >= 0 && indexRow < jaggedArray.Length &&
                    indexCol >= 0 && indexCol < jaggedArray[indexRow].Length))
                {
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[indexRow][indexCol] += value;
                }

                else if (command == "Subtract")
                {
                    jaggedArray[indexRow][indexCol] -= value;

                }
            }

            foreach (var numbers in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
