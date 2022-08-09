using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    public class PieceInfo
    {
        public string Composer { get; set; }

        public string Key { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PieceInfo> pieces = new Dictionary<string, PieceInfo>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                pieces.Add(data[0], new PieceInfo { Composer = data[1], Key = data[2] });
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] parts = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string piece = parts[1];

                if (command == "Add")
                {
                    string composer = parts[2];
                    string key = parts[3];

                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }

                    else
                    {
                        pieces.Add(piece, new PieceInfo { Composer = composer, Key = key });

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }

                else if (command == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);

                        Console.WriteLine($"Successfully removed {piece}!");
                    }

                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                else if (command == "ChangeKey")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        string newKey = parts[2];
                        pieces[piece].Key = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }

                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            var sorted = pieces
                .OrderBy(p => p.Key)
                .ThenBy(p => p.Value.Composer);

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Composer}, Key: {kvp.Value.Key}");
            }
        }
    }
}
