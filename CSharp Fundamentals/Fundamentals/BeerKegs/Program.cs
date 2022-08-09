using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double curentVolume = 0;
            string biggestKeg = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;

                if (volume > curentVolume)
                {
                    curentVolume = volume;

                    biggestKeg = model;

                }

            }
            
            Console.WriteLine(biggestKeg);

        }
    }
}
