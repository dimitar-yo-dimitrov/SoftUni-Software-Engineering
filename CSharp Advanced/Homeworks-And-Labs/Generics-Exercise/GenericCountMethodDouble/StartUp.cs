using System;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Add(input);
            }

            double comparedElement = double.Parse(Console.ReadLine());

            Console.WriteLine($"{box.CountGreaterThanTheValue(comparedElement)}");
        }
    }
}
