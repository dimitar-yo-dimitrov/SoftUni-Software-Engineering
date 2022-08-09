using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> biscuits = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string outOf = string.Empty;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Eat")
                {
                    biscuits.Remove(outOf);
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[0];
                string biscuit = parts[1];

                if (comand == "Update-Any")
                {

                    for (int i = 0; i < biscuits.Count; i++)
                    {
                        if (biscuit == biscuits[i])
                        {
                            biscuits[i] = "Out of stock";
                            outOf = biscuits[i];
                        }
                    }
                }

                else if (comand == "Remove")
                {
                    int index = int.Parse(parts[2]);

                    for (int i = 0; i < biscuits.Count; i++)
                    {
                        if (index == i)
                        {
                            biscuits[i] = biscuit;
                        }
                       
                    }
                }

                else if (comand == "Update-Last")
                {
                    for (int i = 0; i < biscuits.Count; i++)
                    {
                        if (i == biscuits.Count - 1)
                        {
                            biscuits[i] = biscuit;
                        }
                    }
                }

                else if (comand == "Rearrange")
                {

                    if (biscuits.Contains(biscuit))
                    {
                        biscuits.Remove(biscuit);
                        biscuits.Add(biscuit);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", biscuits));
        }
    }
}
