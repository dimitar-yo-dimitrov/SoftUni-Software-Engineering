using System;

namespace _02.PawnWars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rows = 8;
            var cols = 8;

            var field = new char[rows, cols];

            var rowW = 0;
            var colW = 0;

            var rowB = 0;
            var colB = 0;

            for (int row = 0; row < rows; row++)
            {
                var fieldRow = Console.ReadLine()
                    ?.ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    if (fieldRow != null)
                    {
                        field[row, col] = fieldRow[col];

                        if (fieldRow[col] == 'w')
                        {
                            rowW = row;
                            colW = col;
                        }

                        if (fieldRow[col] == 'b')
                        {
                            rowB = row;
                            colB = col;
                        }
                    }
                }
            }

            while (true)
            {
                field[rowW, colW] = '-';
                field[rowB, colB] = '-';

                if (rowW - 1 == rowB)
                {
                    if (colW - 1 == colB || colW + 1 == colB)
                    {
                        rowW = rowB;
                        colW = colB;

                        Console.WriteLine($"Game over! white capture on {ConvertCoordinates(rowW, colW)}.");
                        field[rowW, colW] = 'w';
                        break;
                    }
                }

                rowW--;
                field[rowW, colW] = 'w';

                if (rowW == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {ConvertCoordinates(rowW, colW)}.");
                    break;
                }

                if (rowB + 1 == rowW)
                {
                    if (colB - 1 == colW || colB + 1 == colW)
                    {
                        rowB = rowW;
                        colB = colW;

                        Console.WriteLine($"Game over! Black capture on {ConvertCoordinates(rowW, colW)}.");
                        field[rowB, colB] = 'b';
                        break;
                    }
                }

                rowB++;
                field[rowB, colB] = 'b';

                if (rowB != 7) continue;
                Console.WriteLine(
                    $"Game over! Black pawn is promoted to a queen at {ConvertCoordinates(rowW, colW)}.");
                break;
            }
        }

        private static string ConvertCoordinates(int rowW, int colW)
        {
            var symbol = (char)(97 + colW);

            return $"{symbol}{8 - rowW}";
        }
    }
}
