using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> charStack = new Stack<char>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                charStack.Push(input[i]);
            }

            while (charStack.Count > 0)
            {
                Console.Write(charStack.Pop());
            }

            Console.WriteLine();
        }
    }
}
