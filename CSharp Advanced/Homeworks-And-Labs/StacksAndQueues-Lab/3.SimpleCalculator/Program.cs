using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> calculate = new Stack<string>(input);

            while (calculate.Count > 1)
            {
                int a = int.Parse(calculate.Pop());
                string op = calculate.Pop();
                int b = int.Parse(calculate.Pop());

                if (op == "+")
                {
                    calculate.Push((a + b).ToString());
                }
                else
                {
                    calculate.Push((a - b).ToString());
                }
            }

            Console.WriteLine(calculate.Pop());
        }
    }
}
