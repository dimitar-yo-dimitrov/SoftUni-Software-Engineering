using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");
            List<string> textLIne = new List<string>();

            int lineCounter = 1;

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = lines[i].Count(char.IsLetter);
                int punctuationCount = lines[i].Count(char.IsPunctuation);

                textLIne.Add($"Line {lineCounter}: {lines[i]}. ({lettersCount})({punctuationCount})");
            }

            File.WriteAllLines("output.txt", textLIne);
        }
    }
}
