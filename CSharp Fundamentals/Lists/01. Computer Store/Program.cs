using System;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWithoutTaxes = 0;
            double totalPrice = 0;
            double taxes = 0;

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "special")
                {
                    Console.WriteLine("Congratulations you've just bought a new computer!");
                    Console.WriteLine($"Price without taxes: {priceWithoutTaxes:f2}$");

                    taxes = priceWithoutTaxes * 0.20;
                    Console.WriteLine($"Taxes: {taxes:f2}$");
                    Console.WriteLine("-----------");

                    totalPrice = priceWithoutTaxes * 1.2;
                    totalPrice *= 0.90;
                    Console.WriteLine($"Total price: {totalPrice:f2}$");
                    break;
                }

                else if (comand == "regular")
                {
                    if (priceWithoutTaxes == 0)
                    {
                        Console.WriteLine("Invalid order!");
                        break;
                    }

                    Console.WriteLine("Congratulations you've just bought a new computer!");
                    Console.WriteLine($"Price without taxes: {priceWithoutTaxes:f2}$");

                    taxes = priceWithoutTaxes * 0.20;
                    Console.WriteLine($"Taxes: {taxes:f2}$");
                    Console.WriteLine("-----------");

                    totalPrice = priceWithoutTaxes * 1.2;
                    Console.WriteLine($"Total price: {totalPrice:f2}$");
                    break;
                }

                else if (double.Parse(comand) < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                priceWithoutTaxes += double.Parse(comand);

                if (priceWithoutTaxes == 0)
                {
                    Console.WriteLine("Invalid order!");
                    break;
                }
            }
        }
    }
}
