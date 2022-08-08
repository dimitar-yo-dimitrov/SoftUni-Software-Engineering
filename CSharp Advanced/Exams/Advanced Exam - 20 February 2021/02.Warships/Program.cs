using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var field = new char[size, size];

            int countOfShipsFirst = 0;
            int countOfShipsSecond = 0;
            int totalCountShipsDestroyed = 0;
            bool print = true;

            var attackCoordinates = Console.ReadLine()
                .Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int row = 0; row < size; row++)
            {
                var fieldRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = fieldRow[col];

                    if (field[row, col] == '<')
                    {
                        countOfShipsFirst++;
                    }
                    else if (field[row, col] == '>')
                    {
                        countOfShipsSecond++;
                    }
                }
            }

            while (attackCoordinates.Any())
            {
                int currentRow = attackCoordinates[0];
                int currentCol = attackCoordinates[1];

                if (IsValidIndexes(currentRow, currentCol, field))
                {

                    if (IsFirstPlayer(field, currentRow, currentCol))
                    {
                        countOfShipsFirst--;
                        totalCountShipsDestroyed++;
                        field[currentRow, currentCol] = 'X';
                    }

                    else if (IsSecondPlayer(field, currentRow, currentCol))
                    {
                        countOfShipsSecond--;
                        totalCountShipsDestroyed++;
                        field[currentRow, currentCol] = 'X';
                    }

                    else if (field[currentRow, currentCol] == '#')
                    {
                        for (int row = currentRow - 1; row <= currentRow + 1; row++)
                        {
                            for (int col = currentCol - 1; col <= currentCol + 1; col++)
                            {
                                if (IsValidIndexes(row, col, field))
                                {
                                    if (IsFirstPlayer(field, row, col))
                                    {
                                        field[currentRow, currentCol] = 'X';
                                        countOfShipsFirst--;
                                        totalCountShipsDestroyed++;
                                    }
                                    else if (IsSecondPlayer(field, row, col))
                                    {
                                        field[currentRow, currentCol] = 'X';
                                        countOfShipsSecond--;
                                        totalCountShipsDestroyed++;
                                    }
                                }
                            }
                        }
                    }
                }

                attackCoordinates.RemoveRange(0, 2);

                if (countOfShipsFirst <= 0)
                {
                    Console.WriteLine
                        ($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                    print = false;
                    break;
                }

                if (countOfShipsSecond <= 0)
                {
                    Console.WriteLine
                        ($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                    print = false;
                    break;
                }
            }

            if (print)
            {
                Console.WriteLine($"It's a draw! Player One has {countOfShipsFirst} ships left. Player Two has {countOfShipsSecond} ships left.");
            }
        }

        public static bool IsSecondPlayer(char[,] field, int row, int col)
        {
            return field[row, col] == '>';
        }

        public static bool IsFirstPlayer(char[,] field, int row, int col)
        {
            return field[row, col] == '<';
        }

        public static bool IsValidIndexes(int row, int col, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) &&
                   col >= 0 && col < field.GetLength(0);
        }
    }
}
