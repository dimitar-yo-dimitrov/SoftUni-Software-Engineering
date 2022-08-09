using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string text = Console.ReadLine();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                int index = GetIndex(currentNumber);

                char currentChar = GetCharFromText(index, text);

                Console.Write(currentChar);

                int countIndex = ClculateCountIndex(index, text);
                string newText = text.Remove(countIndex, 1);
                text = newText;
            }

            Console.WriteLine();
        }

        private static int ClculateCountIndex(int index, string text)
        {
            int countIndex = 0;

            for (int i = 0; i < index; i++)
            {
                countIndex++;

                if (countIndex == text.Length)
                {
                    countIndex = 0;
                }
            }

            return countIndex;
        }

        private static char GetCharFromText(int index, string text)
        {
            int countIndex = 0;

            for (int i = 0; i < index; i++)
            {
                countIndex++;

                if (countIndex == text.Length)
                {
                    countIndex = 0;
                }
            }

            char currentChar = text[countIndex];

            return currentChar;
        }

        private static int GetIndex(int number)
        {
            int index = 0;

            while (number > 0)
            {
                int currentNumber = number % 10;
                index += currentNumber;
                number /= 10;
            }

            return index;
        }
    }
}
