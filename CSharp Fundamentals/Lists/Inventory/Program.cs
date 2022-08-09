using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Craft!")
                {
                    break;
                }

                string[] parts = line
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[0];
                string item = parts[1];

                if (comand == "Collect")
                {
                    if (items.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        items.Add(item);
                    }
                }

                else if (comand == "Drop")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }

                else if (comand == "Combine Items")
                {
                    string[] newItem = item
                        .Split(":", StringSplitOptions.RemoveEmptyEntries);

                    string oldItem = newItem[0];
                    string addItem = newItem[1];
                    int index = items.IndexOf(oldItem);

                    if (items.Contains(oldItem))
                    {
                        items.Insert(index + 1, addItem);
                    }
                }
                
                else if (comand == "Renew")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
