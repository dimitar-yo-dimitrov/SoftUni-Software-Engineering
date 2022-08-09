using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbers = new List<int>(firstNumbers.Count + secondNumbers.Count);

            int limit = Math.Min(firstNumbers.Count, secondNumbers.Count);

            for (int i = 0; i < limit; i++)
            {
                numbers.Add(firstNumbers[i]);
                numbers.Add(secondNumbers[i]);

               
            }

            if (firstNumbers.Count != secondNumbers.Count)
            {
                if (firstNumbers.Count > secondNumbers.Count)
                {
                    numbers.AddRange(GetRemindingNumbers(firstNumbers, secondNumbers));
                }

                else
                {
                    numbers.AddRange(GetRemindingNumbers(secondNumbers, firstNumbers));

                }
            }

            Console.Write(string.Join(" ", numbers));
        }
        private static List<int> GetRemindingNumbers(List<int> longerList, List<int> shorterList)
        {
            if (longerList.Count <= shorterList.Count)
            {
                throw new ArgumentException();
            }

            List<int> result = new List<int>();

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                result.Add(longerList[i]);
            }

            return result;
        }
    }
}
