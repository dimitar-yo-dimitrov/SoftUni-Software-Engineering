using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class Program
    {
        public class Box
        {
            public Box()
            {
                Item = new Item();
            }
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }

        public class Item
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string serialNumber = parts[0];
                string itemName = parts[1];
                int quantity = int.Parse(parts[2]);
                decimal itemPrice = decimal.Parse(parts[3]);

                decimal boxPrice = quantity * itemPrice;

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.Quantity = quantity;
                box.Price = boxPrice;

                box.Item = new Item()
                {
                    Name = itemName,
                    Price = itemPrice
                };


                boxes.Add(box);
            }

            foreach (Box box in boxes.OrderByDescending(x => x.Price))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
    }
}
