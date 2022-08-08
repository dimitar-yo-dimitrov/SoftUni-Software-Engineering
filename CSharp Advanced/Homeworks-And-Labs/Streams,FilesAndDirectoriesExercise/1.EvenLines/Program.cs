using System;
using System.IO;
using System.Linq;

namespace _1.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "text.txt";

            using var reader = new StreamReader(filePath);

            int counter = 0;

                while (true)
                {
                    string currentLine = reader.ReadLine();

                    if (currentLine == null)
                    {
                        break;
                    }

                    if (counter % 2 == 0)
                    {
                        string replacedLine = ReplaceSymbols(currentLine);

                        var reversedLine = replacedLine
                            .Split()
                            .Reverse()
                            .ToArray();

                        Console.WriteLine(string.Join(" ", reversedLine));
                    }

                    counter++;
                }
        }

        private static string ReplaceSymbols(string currentLine)
        {
            //{ "-", ",", ".", "!", "?"}

            return currentLine
                .Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@");
        }
    }
}
