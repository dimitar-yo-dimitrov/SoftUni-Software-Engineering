using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] textLines = File.ReadAllLines("text.txt");
            string[] wordsLines = File.ReadAllLines("words.txt");

            foreach (var word in wordsLines)
            {
                if (!wordsCount.ContainsKey(word.ToLower()))
                {
                    wordsCount.Add(word, 0);
                }
            }

            foreach (var line in textLines)
            {
                string[] currentWords = line
                    .ToLower()
                    .Split(new char[] { ' ', '-', ',', '.', '!', '?', '\'' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in currentWords)
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        wordsCount[word]++;
                    }
                }
            }

            //actualResult.txt

            foreach (var kvp in wordsCount)
            {
                //quick - 2

                string result = $"{kvp.Key} - {kvp.Value}{Environment.NewLine}";
                File.AppendAllText("actualResult.txt", result);
            }

            //expectedResult.txt

            foreach (var kvp in wordsCount.OrderByDescending(x => x.Value))
            {
                //quick - 2

                string result = $"{kvp.Key} - {kvp.Value}{Environment.NewLine}";
                File.AppendAllText("expectedResult.txt", result);
            }
        }
    }
}
