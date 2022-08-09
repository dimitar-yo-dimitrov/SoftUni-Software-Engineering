using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace midExamProblem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrey = Console.ReadLine()
               .Split('|', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Done")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[1];

                if (comand == "Left")
                {
                    int index = int.Parse(parts[2]);

                    if (index - 1 >= 0 && index < arrey.Length)
                    {
                        string temp = arrey[index];

                        arrey[index] = arrey[index - 1];

                        arrey[index - 1] = temp;
                    }
                }

                else if (comand == "Right")
                {
                    int index = int.Parse(parts[2]);

                    if (index >= 0 && index + 1 < arrey.Length)
                    {
                        string temp = arrey[index];

                        arrey[index] = arrey[index + 1];

                        arrey[index + 1] = temp;
                    }
                }

                else if (comand == "Even" || comand == "Odd")
                {
                    for (int i = 0; i < arrey.Length; i++)
                    {
                        if (parts[1] == "Even")
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write(arrey[i] + " ");
                            }
                        }

                        else
                        {
                            if (i % 2 != 0)
                            {
                                Console.Write(arrey[i] + " ");
                            }
                        }
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine($"You crafted {string.Join("", arrey)}!");
        }
    }
}

