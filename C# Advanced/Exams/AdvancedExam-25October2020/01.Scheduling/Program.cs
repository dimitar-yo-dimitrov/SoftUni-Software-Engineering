using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            int wantedValue = int.Parse(Console.ReadLine());

            while (true)
            {
                var task = tasks.Peek();
                var thread = threads.Peek();

                if (task == wantedValue)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {wantedValue}");
                    break;
                }

                if (task <= thread)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }

                else if (task > thread)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
