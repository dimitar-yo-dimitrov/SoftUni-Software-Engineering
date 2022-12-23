using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            var words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> filterFunc = w => w.Length <= length;

            Console.WriteLine(string.Join(Environment.NewLine, words.Where(filterFunc)));
        }
    }
}
