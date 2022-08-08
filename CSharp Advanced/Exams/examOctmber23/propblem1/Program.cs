using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var vowels = new Queue<char>(Console.ReadLine()
                .Split()
                .Select(char.Parse));
            
            var consonants = new Stack<char>(Console.ReadLine()
                .Split()
                .Select(char.Parse));

            var letters = new List<char>();

            while (consonants.Count > 0)
            {
                var vowel = vowels.Peek();
                var consonant = consonants.Peek();

                if (vowel == 'e' || vowel == 'a' ||  
                    vowel == 'u' || vowel == 'o' ||  vowel == 'i')
                {
                       letters.Add(vowel);
                }
                
                if (consonant == 'p' || consonant == 'r' || consonant == 'f' || consonant == 'l' ||  
                    consonant == 'k' || consonant == 'l' || consonant == 'v')
                {
                       letters.Add(consonant);
                } 
                
                vowels.Enqueue(vowels.Dequeue());
                consonants.Pop();

            }

            var words = new List<string>
            {
                "pear",
                "flour",
                "pork",
                "olive"
            };

            var foundedWords = new List<string>();

            var exist = true;

            foreach (var word in words)
            {
                if (word.Any(t => !letters.Contains(t)))
                {
                    exist = false;
                }

                if (exist)
                {
                    foundedWords.Add(word);
                }
            }

            Console.WriteLine($"Words found: {foundedWords.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, foundedWords));
        }
    }
}
