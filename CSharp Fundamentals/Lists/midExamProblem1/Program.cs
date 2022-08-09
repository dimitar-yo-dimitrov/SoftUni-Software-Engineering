using System;

namespace midExamProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            float budget = float.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            float priceOfFlour = float.Parse(Console.ReadLine());
            float priceOfEgg = float.Parse(Console.ReadLine());
            float priceOfApron = float.Parse(Console.ReadLine());

            double totalPrice = priceOfApron * (Math.Ceiling(students * 1.20)) + priceOfEgg * students * 10 + priceOfFlour * students;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    totalPrice -= priceOfFlour;
                }
            }

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                double neededMoney = (budget - totalPrice) * - 1;
                Console.WriteLine($"{neededMoney:f2}$ more needed.");
            }
        }
    }
}
