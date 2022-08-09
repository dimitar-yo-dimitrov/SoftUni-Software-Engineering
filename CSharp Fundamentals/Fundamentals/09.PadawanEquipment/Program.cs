using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            int lightSabersCount = (int)Math.Ceiling(countOfStudents *  1.1);
            int beltsCount = countOfStudents - countOfStudents / 6;

            double totalPrise = (priceOfLightsabers * lightSabersCount) + (priceOfRobes * countOfStudents) + (priceOfBelts * beltsCount);

            if (totalPrise <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrise:F2}lv.");
            }

            else
            {
                Console.WriteLine($"Ivan Cho will need {totalPrise - budget:F2}lv more.");    
            }
                         
        }
    }
}
