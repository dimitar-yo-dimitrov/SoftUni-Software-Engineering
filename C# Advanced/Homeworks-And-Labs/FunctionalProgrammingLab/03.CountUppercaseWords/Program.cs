using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //Predicate<string> upperCaseFirstLetter = word => char.IsUpper(word[0]);

            var text = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> upperCaseFirstLetter = word => char.IsUpper(word[0]);

            var upperLetterWords = text.Where(upperCaseFirstLetter);

            foreach (var word in upperLetterWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
