using System;

namespace GenericCountMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                box.Add(input);
            }

            string comparedElement = Console.ReadLine();

            Console.WriteLine($"{box.CountGreaterThanTheValue(comparedElement)}");
        }
    }
}
