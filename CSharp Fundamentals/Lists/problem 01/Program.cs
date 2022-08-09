using System;

namespace problem_01
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            int monts = int.Parse(Console.ReadLine());

            double sevedMoney = 0;

            for (int i = 1; i <= monts; i++)
            {

                if (i % 2 != 0 && i != 1)
                {
                    sevedMoney *= 0.84;
                }


                if (i % 4 == 0)
                {
                    sevedMoney *= 1.25;
                }

                sevedMoney += neededMoney * 0.25;
            }

            if (sevedMoney > neededMoney)
            {

                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {sevedMoney - neededMoney:f2}lv. for souvenirs.") ;
            }

            else
            {
                Console.WriteLine($"Sorry. You need {neededMoney - sevedMoney:f2}lv. more.");
            }
        }
    }
}
