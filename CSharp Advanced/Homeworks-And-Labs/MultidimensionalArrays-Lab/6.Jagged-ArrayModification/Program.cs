using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = new int[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    jaggedArray[row][col] = currentRow[col];
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
                int row = int.Parse(parts[1]);
                int col = int.Parse(parts[2]);
                int value = int.Parse(parts[3]);

                if (row < rows && row >= 0 && col < rows && col >= 0)
                {
                    if (command == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }

                    else if (command == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            foreach (var numbers in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
