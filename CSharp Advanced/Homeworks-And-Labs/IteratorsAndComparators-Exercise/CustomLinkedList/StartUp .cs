using System;

namespace CustomDoublyLinkedList 

{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList<int>();

            linkedList.AddFirst(15);
            linkedList.AddFirst(10);
            linkedList.AddLast(22);
            Console.WriteLine($"Count: {linkedList.Count}");
            
            linkedList.ForEach(x => Console.WriteLine(x));
            
            Console.WriteLine($"Removed:{linkedList.RemoveFirst()}");
            
            linkedList.ForEach(x => Console.WriteLine(x));
            
            Console.WriteLine($"Removed:{linkedList.RemoveLast()}");
            Console.WriteLine($"Count: {linkedList.Count}");

            linkedList.ForEach(Console.WriteLine);
        }
    }
}
