using System;
using System.Threading.Channels;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            var sizeRow = int.Parse(Console.ReadLine());

            char[][] field = new char[sizeRow][];

            for (int i = 0; i < sizeRow; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }

            // find player
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < sizeRow; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'A')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            //moves
            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var movePlayer = commands[0];
                var rowOrc = int.Parse(commands[1]);
                var colOrc = int.Parse(commands[2]);

                armor--;
                field[rowOrc][colOrc] = 'O';
                field[playerRow][playerCol] = '-';

                // “up”, “down”, “left”, “right”
                if (movePlayer == "up" && playerRow - 1 >= 0)
                {
                    playerRow--;
                }

                else if (movePlayer == "down" && playerRow + 1 < sizeRow)
                {
                    playerRow++;
                }

                else if (movePlayer == "left" && playerCol - 1 >= 0)
                {
                    playerCol--;
                }

                else if (movePlayer == "right" && playerCol + 1 < sizeRow)
                {
                    playerCol++;
                }

                if (field[playerRow][playerCol] == 'O')
                {
                    armor -= 2;
                }

                if (field[playerRow][playerCol] == 'M')
                {
                    field[playerRow][playerCol] = '-';

                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    field[playerRow][playerCol] = 'X';

                    Console.WriteLine($"The army was defeated at {playerRow};{playerCol}.");
                    break;
                }

                field[playerRow][playerCol] = 'A';
            }

            for (int row = 0; row < sizeRow; row++)
            {
                Console.WriteLine(field[row]);
            }
        }
    }
}
