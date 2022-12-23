using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                var hat = hats.Peek();
                var scarf = scarfs.Peek();

                if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hat += 1;
                    hats.Push(hat);
                }

                else if (hat < scarf)
                {
                    hats.Pop();
                }

                else if (hat > scarf)
                {
                    hat += scarf;
                    hats.Pop();
                    scarfs.Dequeue();

                    sets.Add(hat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
