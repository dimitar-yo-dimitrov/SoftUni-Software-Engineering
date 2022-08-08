using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Queue<string> playList = new Queue<string>(songs);

            while (playList.Any())
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    playList.Dequeue();
                }

                else if (command.StartsWith("Add"))
                {
                    var songFullName = command.Substring(4);

                    if (playList.Contains(songFullName))
                    {
                        Console.WriteLine($"{songFullName} is already contained!");
                        continue;
                    }

                    playList.Enqueue(songFullName);
                }

                else if (command.StartsWith("Show"))
                {
                    Console.WriteLine($"{string.Join(", ", playList)}");
                }
            }

            if (playList.Count == 0)
            {
                Console.WriteLine($"No more songs!");
            }
        }
    }
}
