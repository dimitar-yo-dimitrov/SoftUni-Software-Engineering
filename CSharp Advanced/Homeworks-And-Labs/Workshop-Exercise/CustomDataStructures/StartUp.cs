using System;
using System.Collections.Generic;

namespace CustomDataStructures
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var list = new CustomList();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(1);

            list.Insert(0, 1);

            list.Swap(0, 2);

            list.ForEach(Console.WriteLine);

            Console.WriteLine();

            var stack = new CustomStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            stack.Pop();
            stack.Pop();

            Console.WriteLine(stack.Peek());
            Console.WriteLine();

            stack.ForEach(Console.WriteLine);
        }
    }
}
