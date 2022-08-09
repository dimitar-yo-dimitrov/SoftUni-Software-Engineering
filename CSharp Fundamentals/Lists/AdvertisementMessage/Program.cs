using System;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events = new[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = new[]
            {
                "Diana", 
                "Petya", 
                "Stella", 
                "Elena",
                "Katya", 
                "Iva", 
                "Annie", 
                "Eva"
            };

            string[] citys = new[]
            {
                "Burgas", 
                "Sofia", 
                "Plovdiv", 
                "Varna", 
                "Ruse"
            };

            int n = int.Parse(Console.ReadLine());

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                int phraseIdx = random.Next(0, phrases.Length);
                int eventIdx = random.Next(0, events.Length);
                int authorIdx = random.Next(0, authors.Length);
                int cityIdx = random.Next(0, citys.Length);
                
                string result = $"{phrases[phraseIdx]} {events[eventIdx]} {authors[authorIdx]} – {citys[cityIdx]}.";

                Console.WriteLine(result);
            }
        }
    }
}
