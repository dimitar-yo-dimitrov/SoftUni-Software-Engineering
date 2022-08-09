using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal[]> items = new Dictionary<string, decimal[]>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "buy")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string product = parts[0];
                decimal price = decimal.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (!items.ContainsKey(product))
                {
                    items[product] = new decimal[2];

                    items[product][0] = price;
                    items[product][1] = quantity;
                }

                else
                {
                    items[product][0] = price;
                    items[product][1] += quantity;
                }
            }

            foreach (var kvp in items)
            {
                decimal totalPrice = kvp.Value[0] * kvp.Value[1];
                Console.WriteLine($"{kvp.Key} -> {totalPrice:f2}");
            }
        }
    }
}
