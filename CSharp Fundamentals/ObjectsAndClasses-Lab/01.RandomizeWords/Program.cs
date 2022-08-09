using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var texts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();

            for (int i = 0; i < texts.Length; i++)
            {
                int position = rnd.Next(texts.Length);

                string text = texts[i];
                texts[i] = texts[position];
                texts[position] = text;
            }

            Console.WriteLine(string.Join(Environment.NewLine, texts));
        }
    }
}
