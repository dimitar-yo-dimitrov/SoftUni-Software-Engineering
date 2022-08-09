using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();
            List<string> characters = new List<string>();


            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    numbers.Add(int.Parse(input[i].ToString()));
                }

                else
                {
                    characters.Add(input[i].ToString());
                }
            }

            List<int> takeList = new List<int>();
            List<int> scipList = new List<int>();

            for (int n = 0; n < numbers.Count; n++)
            {
                if (n % 2 == 0)
                {
                    takeList.Add(numbers[n]);
                }

                else
                {
                    scipList.Add(numbers[n]);
                }
            }

            StringBuilder result = new StringBuilder();

            int index = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(characters);

                temp = temp.Skip(index)
                    .Take(takeList[i])
                    .ToList();

                result.Append(string.Join("", temp));

                index += takeList[i] + scipList[i];
            }

            Console.WriteLine(result.ToString());
        }
    }
}
