using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legenderyItems = new Dictionary<string, int>()
            {
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0}
            };

            Dictionary<string, int> junkItems = new Dictionary<string, int>();

            bool isRunning = true;
            string winnerItem = string.Empty;

            while (isRunning)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < parts.Length; i += 2)
                {
                    int quantity = int.Parse(parts[i]);
                    string item = parts[i + 1].ToLower();

                    if (legenderyItems.ContainsKey(item))
                    {
                        winnerItem = item;
                        legenderyItems[item] += quantity;

                        if (legenderyItems[item] >= 250)
                        {
                            legenderyItems[item] -= 250;
                            isRunning = false;
                            break;
                        }
                    }

                    else
                    {
                        if (junkItems.ContainsKey(item))
                        {
                            junkItems[item] += quantity;
                        }
                        else
                        {
                            junkItems.Add(item, quantity);
                        }
                    }
                }
            }


            if (winnerItem == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }

            else if (winnerItem == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }

            else if (winnerItem == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            var sortedLegenderyItems = legenderyItems
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key);

            foreach (var kvp in sortedLegenderyItems)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            var sortedJunkItem = junkItems
                .OrderBy(i => i.Key);

            foreach (var kvp in sortedJunkItem)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
