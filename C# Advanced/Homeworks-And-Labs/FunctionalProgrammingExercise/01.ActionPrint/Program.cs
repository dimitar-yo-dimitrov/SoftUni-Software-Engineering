using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> action = Print;
            action(input);

            Console.WriteLine();
        }

        private static void Print(string[] words)
        {
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
