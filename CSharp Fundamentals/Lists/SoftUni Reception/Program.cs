using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int allEmployee = firstEmployee + secondEmployee + thirdEmployee;

            int neededTime = (int) Math.Ceiling((double) students / allEmployee);

            int breakTime = neededTime / 3;

            if (neededTime % 3 == 0 && breakTime > 0)
            {
                neededTime--;
            }

            Console.WriteLine($"Time needed: {neededTime + breakTime}h.");
        }
    }
}
