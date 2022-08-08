using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Revision")
                {
                    break;
                }

                string[] parts = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string nameOfShop = parts[0];
                string nameOfProduct = parts[1];
                double price = double.Parse(parts[2]);

                if (!shops.ContainsKey(nameOfShop))
                {
                    shops.Add(nameOfShop, new Dictionary<string, double>());
                }

                shops[nameOfShop].Add(nameOfProduct, price);
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
