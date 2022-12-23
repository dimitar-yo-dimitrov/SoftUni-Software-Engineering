using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            int[] clientsAndTheirOrders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(clientsAndTheirOrders);

            Console.WriteLine(orders.Max());

            for (int i = 0; i < clientsAndTheirOrders.Length; i++)
            {
                if (orders.Count != 0 && quantityOfFood < clientsAndTheirOrders[i])
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    break;
                }

                quantityOfFood -= clientsAndTheirOrders[i];
                orders.Dequeue();
            }

            if (orders.Count == 0)
            {
                Console.WriteLine($"Orders complete");
            }
        }
    }
}
