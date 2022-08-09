using System;
using System.Collections.Generic;
using System.Linq;
namespace midExamProblem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "end")
                {
                    break;
                }

                string[] parts = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string line = parts[0];
                string item = parts[1];

                switch (line)
                {
                    case "Chat":

                        list.Add(item);

                        break;

                    case "Delete":

                        if (list.Contains(item))
                        {
                            list.Remove(item);
                        }

                        break;

                    case "Edit":

                        string newItem = parts[2];
                        int idx = list.IndexOf(item);

                        if (list.Contains(item))
                        {
                            list.Insert(idx, newItem);
                            list.Remove(item);
                        }

                        break;

                    case "Pin":

                        if (list.Contains(item))
                        {
                            list.Remove(item);
                            list.Add(item);
                        }

                        break;

                    case "Spam":


                        for (int i = 1; i < parts.Length; i++)
                        {
                            list.Add(parts[i]);
                        }

                        break;
                }
            }
            
            list.Remove(list[0]);

            Console.Write(string.Join(Environment.NewLine, list));
        }
    }
}
