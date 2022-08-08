using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<string>();

            while (true)
            {
                var commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "END")
                {
                    break;
                }

                else if (commands[0] == "Push")
                {
                    stack.Push(commands.Skip(1).Select(e => e.Split(",").First()).ToArray());
                }

                else if (commands[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("No elements");
                    }
                }
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
