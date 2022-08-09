using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger maxSnowballValue = -1;
            string result = string.Empty;

            for (int i = 0; i < number; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowBallValue = BigInteger.Pow(snowballSnow / snowballTime , snowballQuality);

                if (snowBallValue > maxSnowballValue)
                {
                    maxSnowballValue = snowBallValue;

                    result = $"{snowballSnow} : {snowballTime} = {snowBallValue} ({snowballQuality})";
                }
            }

            Console.WriteLine(result);
        }
    }
}
