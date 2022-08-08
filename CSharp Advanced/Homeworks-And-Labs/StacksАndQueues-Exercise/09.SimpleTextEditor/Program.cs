using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            Stack<string> text = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "1")
                {
                    text.Push(sb.ToString());
                    string appendText = command[1];
                    sb.Append(appendText);
                }

                else if (command[0] == "2")
                {
                    int index = int.Parse(command[1]);
                    text.Push(sb.ToString());
                    sb.Remove(sb.Length - index, index);
                }

                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]) - 1;

                    if (index >= 0 && index < sb.Length)
                    {
                        Console.WriteLine(sb[index]);
                    }
                }

                else if (command[0] == "4")
                {
                    sb.Clear();
                    sb.Append(text.Pop());
                }
            }
        }
    }
}
