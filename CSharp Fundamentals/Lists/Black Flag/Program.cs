using System;
using System.Linq;

namespace Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            uint days = uint.Parse(Console.ReadLine());
            short dailyPlunder = short.Parse(Console.ReadLine());
            double expectedPlunder = float.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                
                if (i % 3 == 0)
                {
                    double addPlunder = dailyPlunder * 1.50;
                    totalPlunder += addPlunder;
                    totalPlunder -= dailyPlunder;
                }

                totalPlunder += dailyPlunder;

                if (i % 5 == 0)
                {
                    totalPlunder *= 0.70;
                }
            }


            

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:F2} plunder gained.");
            }
            else
            {
                double leftInPercentege = totalPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {leftInPercentege:F2}% of the plunder.");
            }
        }
    }
}
