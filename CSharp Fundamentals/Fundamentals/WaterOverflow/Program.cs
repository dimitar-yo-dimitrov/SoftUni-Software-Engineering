using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = int.Parse(Console.ReadLine());

            int capacity = 255;
            int sumLiters = 0;
            int litersInTheTank = 0;


            for (int i = 0; i < count; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                sumLiters += liters;

                if (sumLiters > capacity)
                {
                    Console.WriteLine($"Insufficient capacity!");

                    sumLiters -= liters;

                    liters -= liters;
                }

                litersInTheTank += liters;

            }

            Console.WriteLine(litersInTheTank);
        }
    }
}
