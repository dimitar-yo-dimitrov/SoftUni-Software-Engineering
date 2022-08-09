using System;
using System.Collections.Generic;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] texts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();

            for (int i = 0; i < texts.Length; i++)
            {
                int pos = rnd.Next(texts.Length);

                string text = texts[i];
                texts[i] = texts[pos];
                texts[pos] = text;
            }

            Console.WriteLine(string.Join(Environment.NewLine, texts));
        }
    }
}
