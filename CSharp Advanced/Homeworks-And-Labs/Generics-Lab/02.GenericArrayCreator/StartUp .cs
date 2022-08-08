using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            Console.WriteLine(string.Join(" ", strings));

            int[] integers = ArrayCreator.Create(10, 33);
            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
