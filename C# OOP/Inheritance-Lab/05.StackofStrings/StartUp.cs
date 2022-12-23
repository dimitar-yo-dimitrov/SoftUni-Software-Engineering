using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stackElements = new StackOfStrings();

            Console.WriteLine(stackElements.IsEmpty()); // true

            stackElements.AddRange("1", "2", "3");

            Console.WriteLine(stackElements.IsEmpty()); // false
        }
    }
}
