using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            char prevSymbol = '\0';

            StringBuilder result = new StringBuilder();

            foreach (var leter in text)
            {
                if (leter != prevSymbol)
                {
                    result.Append(leter);
                }

                prevSymbol = leter;
            }

            Console.WriteLine(result);
        }
    }
}
