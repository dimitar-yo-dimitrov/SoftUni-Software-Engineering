using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (firstList.Count > secondList.Count)
            {
                var mixedList = firstList
                    .Take(firstList.Count - 2)
                    .Concat(secondList);

                var result = mixedList.Where(x => x > Math.Min(firstList[firstList.Count - 1], firstList[firstList.Count - 2])
                                                  && x < Math.Max(firstList[firstList.Count - 1], firstList[firstList.Count - 2]));

                Console.WriteLine(string.Join(" ", result.OrderBy(x => x)));
            }

            else
            {
                var mixedList = firstList
                    .Take(secondList.Count - 2)
                    .Concat(secondList);

                var result = mixedList.Where(x => x > Math.Min(secondList[0], secondList[1])
                                                  && x < Math.Max(secondList[0], secondList[1]));

                Console.WriteLine(string.Join(" ", result.OrderBy(x => x)));
            }
        }
    }
}
