using System;
using System.Collections.Generic;
using System.Linq;

namespace demoTrainingProblem_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[0];

                OperationsWithWords(words, parts, comand);


            }

            Console.WriteLine(string.Join(' ', words));
        }
        private static void OperationsWithWords(List<string> words, string[] parts, string comand)
        {
            if (comand == "Delete")
            {
                int index = int.Parse(parts[1]);

                if (index >= 0 && index < words.Count)
                {
                    string removedIdx = words[index];
                    words.RemoveAt(index + 1);

                }
            }

            else if (comand == "Swap")
            {
                string elementA = parts[1];
                string elementB = parts[2];
                int idx1 = words.IndexOf(elementA);
                int idx2 = words.IndexOf(elementB);

                if (words.Contains(elementA) && words.Contains(elementB))
                {
                    string temp = elementA;
                    words[idx1] = elementB;
                    words[idx2] = temp;
                }
            }

            else if (comand == "Put")
            {
                string element = parts[1];
                int index = int.Parse(parts[2]);

                if (index >= 0 && index < words.Count + 1)
                {
                    index -= 1;
                    words.Insert(index, element);
                }
            }

            else if (comand == "Sort")
            {
                words.Reverse();
            }

            else if (comand == "Replace")
            {
                string newWord = parts[1];
                string oldWord = parts[2];
                int idx = words.IndexOf(oldWord);

                if (words.Contains(oldWord))
                {
                    words.Remove(oldWord);
                    words.Insert(idx, newWord);
                }
            }
        }
    }
}
