using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameCount = int.Parse(Console.ReadLine()); 
            double headsetPrice = double.Parse(Console.ReadLine()); 
            double mousePrice = double.Parse(Console.ReadLine()); 
            double keyboardPrice = double.Parse(Console.ReadLine()); 
            double displayPrice = double.Parse(Console.ReadLine());

            int TrashedHeadsets = 0;
            int TrashedMouses = 0;
            int TrashedKeyboards = 0;
            int TrashedDisplays = 0;

            for (int i = 1; i <= gameCount; i++)
            {
                if (i % 2 == 0)
                {
                    TrashedHeadsets += 1;
                }
                
                if (i % 3 == 0)
                {
                    TrashedMouses += 1;
                }
                
                if (i % 6 == 0)
                {
                    TrashedKeyboards += 1;
                }
                
                if (i % 12 == 0)
                {
                    TrashedDisplays += 1;
                }
            }

            double rangeExpenses = (TrashedHeadsets * headsetPrice) + (TrashedMouses * mousePrice) + (TrashedKeyboards * keyboardPrice) + (TrashedDisplays * displayPrice);

            Console.WriteLine($"Rage expenses: {rangeExpenses:F2} lv.");
        }
    }
}
