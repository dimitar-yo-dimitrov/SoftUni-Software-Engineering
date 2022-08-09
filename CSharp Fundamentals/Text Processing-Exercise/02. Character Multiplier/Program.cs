using System;
using System.Linq;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string firstWord = words[0];
            string secondWord = words[1];

            int totalSum = CharacterMultiplier(firstWord, secondWord);

            Console.WriteLine(totalSum);
        }

        private static int CharacterMultiplier(string firstWord, string secondWord)
        {
            int totalSum = 0;

            if (firstWord.Length == secondWord.Length)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    int multiply = firstWord[i] * secondWord[i];
                    totalSum += multiply;
                }
            }

            else
            {
                if (firstWord.Length > secondWord.Length)
                {
                    for (int i = 0; i < secondWord.Length; i++)
                    {
                        int multiply = firstWord[i] * secondWord[i];
                        totalSum += multiply;
                    }

                    for (int i = secondWord.Length; i < firstWord.Length; i++)
                    {
                        totalSum += firstWord[i];
                    }
                }

                if (secondWord.Length > firstWord.Length)
                {
                    for (int i = 0; i < firstWord.Length; i++)
                    {
                        int multiply = firstWord[i] * secondWord[i];
                        totalSum += multiply;
                    }

                    for (int i = firstWord.Length; i < secondWord.Length; i++)
                    {
                        totalSum += secondWord[i];
                    }
                }
            }

            return totalSum;
        }
    }
}
