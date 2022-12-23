using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int days = DateModifier.DifferenceBethwinTwoDate(firstDate, secondDate);

            Console.WriteLine(days);
        }
    }
}
