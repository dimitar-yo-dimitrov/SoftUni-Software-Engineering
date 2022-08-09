using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Yohoho!")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[0];

                if (comand == "Loot")
                {
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (!treasureChest.Contains(parts[i]))
                        {
                            treasureChest.Insert(0, parts[i]);
                        }
                    }
                }

                else if (comand == "Drop")
                {
                    int index = int.Parse(parts[1]);

                    if (index >= 0 && index < treasureChest.Count)
                    {
                        string removedIdx = treasureChest[index];
                        treasureChest.RemoveAt(index);
                        treasureChest.Add(removedIdx);
                    }
                }

                else if (comand == "Steal")
                {
                    List<string> steal = new List<string>();

                    int count = int.Parse(parts[1]);

                    if (count < treasureChest.Count)
                    {
                        for (int i = treasureChest.Count - count; i < treasureChest.Count; i++)
                        {
                            steal.Add(treasureChest[i]);
                        }

                        Console.WriteLine(string.Join(", ", steal));
                        treasureChest.RemoveRange(treasureChest.Count - count, count);
                    }

                    else
                    {
                        for (int i = 0; i < treasureChest.Count; i++)
                        {
                            steal.Add(treasureChest[i]);
                        }

                        Console.WriteLine(string.Join(", ", steal));
                        treasureChest.RemoveRange(0, treasureChest.Count);
                    }
                }
            }

            if (treasureChest.Count != 0)
            {
                double sum = 0;

                foreach (var item in treasureChest)
                {
                    sum += item.Length;
                }

                double average = sum / treasureChest.Count;

                Console.WriteLine($"Average treasure gain: {average:f2} pirate credits.");
            }

            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
