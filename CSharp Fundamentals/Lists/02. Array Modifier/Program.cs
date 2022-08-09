using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int idx1 = 0;
                int idx2 = 0;

                if (parts[0] == "swap")
                {
                    idx1 = int.Parse(parts[1]);
                    idx2 = int.Parse(parts[2]);
                    int idxChange = numbers[idx1];
                    numbers[idx1] = numbers[idx2];
                    numbers[idx2] = idxChange;
                }
                else if (parts[0] == "multiply")
                {
                    idx1 = int.Parse(parts[1]);
                    idx2 = int.Parse(parts[2]);
                    numbers[idx1] *= numbers[idx2];
                }
                else
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
