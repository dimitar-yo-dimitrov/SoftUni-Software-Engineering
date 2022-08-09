using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int countOfMoves = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    Console.WriteLine("Sorry you lose :(");
                    Console.WriteLine(string.Join(" ", elements));
                    break;
                }

                countOfMoves++;

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int idx1 = int.Parse(parts[0]);
                int idx2 = int.Parse(parts[1]);

                if (idx1 >= 0 && 
                    idx1 < elements.Count && 
                    idx2 >= 0 && 
                    idx2 < elements.Count &&
                    idx1 != idx2)
                {
                    if (elements[idx1] == elements[idx2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {elements[idx1]}!");

                        if (idx1 > idx2)
                        {
                            elements.RemoveAt(idx1);
                            elements.RemoveAt(idx2);
                        }
                        else
                        {
                            elements.RemoveAt(idx2);
                            elements.RemoveAt(idx1);
                        }

                        if (elements.Count == 0)
                        {
                            Console.WriteLine($"You have won in {countOfMoves} turns!");
                            break;
                        }
                    }

                    else if (elements[idx1] != elements[idx2])
                    {
                        Console.WriteLine("Try again!");
                    }

                }

                else
                {
                    elements.Insert(elements.Count / 2, $"-{countOfMoves}a");
                    elements.Insert(elements.Count / 2, $"-{countOfMoves}a");
                    
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
            }
        }
    }
}
