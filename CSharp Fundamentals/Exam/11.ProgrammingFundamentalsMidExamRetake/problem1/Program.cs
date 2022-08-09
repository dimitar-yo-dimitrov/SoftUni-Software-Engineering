using System;

namespace problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            double size = double.Parse(Console.ReadLine());

            int numberOfSheets = int.Parse(Console.ReadLine());

            double areaOfGiftBox = size * size * 6;
            double areaOfSheet = 0;

            for (int i = 1; i <= numberOfSheets; i++)
            {
             

                double lenght = double.Parse(Console.ReadLine());
                double widht = double.Parse(Console.ReadLine());

                double currentArea = lenght * widht;
                areaOfSheet += currentArea;

                if (i % 3 == 0)
                {
                    areaOfSheet -= currentArea;
                    areaOfSheet += currentArea * 0.75;
                }
                if (i % 5 == 0)
                {
                    areaOfSheet -= currentArea;
                    continue;
                }

                currentArea = 0;
            }

            if (areaOfGiftBox <= areaOfSheet)
            {
                double paperLeft = areaOfGiftBox / areaOfSheet * 100;
                paperLeft = 100 - paperLeft;
                Console.WriteLine($"You've covered the gift box!");
                Console.WriteLine($"{paperLeft:f2}% wrap paper left.");
            }
            else
            {
                double notCovered = areaOfSheet / areaOfGiftBox * 100;
                notCovered = 100 - notCovered;
                Console.WriteLine($"You are out of paper!");
                Console.WriteLine($"{notCovered:f2}% of the box is not covered.");
            }
        }
    }
}
