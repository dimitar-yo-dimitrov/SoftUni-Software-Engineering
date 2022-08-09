using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "Go Shopping!")
                {
                    break;
                }

                string[] parts = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string line = parts[0];
                string item = parts[1];


                switch (line)
                {
                    case "Urgent":

                        if (list.Contains(item))
                        {
                            continue;
                        }

                        else
                        {
                            list.Insert(0, item);
                        }
                        break;

                    case "Unnecessary":

                        if (list.Contains(item))
                        {
                            list.Remove(item);
                        }
                        break;

                    case "Correct":

                        string newItem = parts[2];
                        int idx = list.IndexOf(item);

                        if (list.Contains(item))
                        {
                            list.Insert(idx, newItem);
                            list.Remove(item);
                        }
                        break;

                    case "Rearrange":

                        if (list.Contains(item))
                        {
                            list.Remove(item);
                            list.Add(item);
                        }
                        break;

                    default:

                        break;

                }
            }
           
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
