using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList randomElement = new RandomList
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10"
            };

            for (int i = 0; i < randomElement.Count; i++)
            {
                Console.WriteLine(randomElement.RandomString());
            }
        }
    }
}
