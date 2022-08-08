using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothesInTheBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            int capacityOfRack = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(clothesInTheBox);

            int sum = 0;
            int countOfRack = 1;

            while (clothes.Any())
            {
                int currentValue = clothes.Peek();

                if (sum + currentValue <= capacityOfRack)
                {
                    sum += currentValue;
                    clothes.Pop();
                }
                else
                {
                    sum = 0;
                    countOfRack++;
                }
            }

            Console.WriteLine(countOfRack);
        }
    }
}
