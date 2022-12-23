using System;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfRows = int.Parse(Console.ReadLine());

            string[][] field = new String[sizeOfRows][];

            for (int i = 0; i < sizeOfRows; i++)
            {
                field[i] = Console.ReadLine().Split();
            }

            int myTokens = 0;
            int opponentTokens = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Gong")
                {
                    break;
                }

                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var row = int.Parse(parts[1]);
                var col = int.Parse(parts[2]);

                if (parts[0] == "Find")
                {
                    if (GetToken(row, col, field))
                    {
                        myTokens++;
                    }
                }

                else if (parts[0] == "Opponent")
                {
                    string direction = parts[3];

                    if (GetToken(row, col, field))
                    {
                        opponentTokens++;

                        for (int i = 0; i < 3; i++)
                        {
                            switch (direction)
                            {
                                //"up", "down", "left", "right".
                                case "up": row--; break;

                                case "down": row++; break;

                                case "left": col--; break;

                                case "right": col++; break;
                            }

                            if (GetToken(row, col, field))
                            {
                                opponentTokens++;
                            }
                        }
                    }
                }
            }

            PrintField(field);

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static bool GetToken(int row, int col, string[][] field)
        {
            if (IsValidIndexes(row, col, field))
            {
                if (field[row][col] == "T")
                {
                    field[row][col] = "-";
                    return true;
                }
            }

            return false;
        }

        private static void PrintField(string[][] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", field[row]));
            }
        }

        private static bool IsValidIndexes(int row, int col, string[][] field)
        {
            return row >= 0 && row < field.Length &&
                   col >= 0 && col < field[row].Length;
        }
    }
}