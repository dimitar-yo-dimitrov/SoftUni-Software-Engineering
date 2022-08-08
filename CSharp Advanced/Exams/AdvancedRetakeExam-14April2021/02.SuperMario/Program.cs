using System;
using System.Threading.Channels;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int sizeRow = int.Parse(Console.ReadLine());

            char[][] field = new char[sizeRow][];

            for (int i = 0; i < sizeRow; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < sizeRow; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'M')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var movePlayer = commands[0];
                var rowEnemy = int.Parse(commands[1]);
                var colEnemy = int.Parse(commands[2]);

                lives--;
                field[rowEnemy][colEnemy] = 'B';
                field[playerRow][playerCol] = '-';

                // "W" (up), "S" (down), "A" (left), "D" (right).

                if (movePlayer == "W" && playerRow - 1 >= 0)
                {
                    playerRow--;
                }

                else if (movePlayer == "S" && playerRow + 1 < sizeRow)
                {
                    playerRow++;
                }

                else if (movePlayer == "A" && playerCol - 1 >= 0)
                {
                    playerCol--;
                }

                else if (movePlayer == "D" && playerCol + 1 < field[playerRow].Length)
                {
                    playerCol++;
                }

                if (field[playerRow][playerCol] == 'B')
                {
                    lives -= 2;
                }

                if (field[playerRow][playerCol] == 'P')
                {
                    field[playerRow][playerCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }

                if (lives <= 0)
                {
                    field[playerRow][playerCol] = 'X';
                    Console.WriteLine($"Mario died at {playerRow};{playerCol}.");
                    break;
                }

                field[playerRow][playerCol] = 'M';
            }

            for (int row = 0; row < sizeRow; row++)
            {
                Console.WriteLine(field[row]);
            }
        }
    }
}
