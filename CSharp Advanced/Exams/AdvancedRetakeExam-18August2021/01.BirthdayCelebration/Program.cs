using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> guests = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).Reverse());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            var wastedFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                if (guests.Peek() <= plates.Peek())
                {
                    wastedFood += guests.Peek() - plates.Peek();
                    guests.Pop();
                }
                else
                {
                   guests.Push(guests.Pop() - plates.Peek());
                }

                plates.Pop();
            }

            Console.WriteLine(guests.Count == 0 ? $"Plates: {string.Join(" ", plates)}" : $"Guests: {string.Join(" ", guests)}");
            Console.WriteLine($"Wasted grams of food: {Math.Abs(wastedFood)}");
        }
    }
}
