using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listy = null;

            while (true)
            {
                var commands = Console.ReadLine().Split();

                if (commands[0] == "END")
                {
                    break;
                }

                else if (commands[0] == "Create")
                {
                    listy = new ListyIterator<string>(commands.Skip(1).ToArray());
                }

                else if (commands[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }

                else if (commands[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }

                else if (commands[0] == "Print")
                {
                    listy.Ptint();
                }
            }
        }
    }
}
