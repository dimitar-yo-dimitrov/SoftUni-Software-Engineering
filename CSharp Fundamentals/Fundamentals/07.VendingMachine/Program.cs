using System;

namespace _07.VendingMachine
{
    class Program
    {

        static void Main(string[] args)
        {
            string comand = Console.ReadLine();

            double prise = 0;
            double curentSum = 0;

            while (comand != "Start")
            {
                double coins = double.Parse(comand);

                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    curentSum += coins;
                }

                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

                comand = Console.ReadLine();
            }

            comand = Console.ReadLine();

            while (comand != "End")
            {
                if (comand == "Nuts")
                {
                    prise = 2;
                }

                else if (comand == "Water")
                {
                    prise = 0.7;
                }

                else if (comand == "Crisps")
                {
                    prise = 1.5;
                }

                else if (comand == "Soda")
                {
                    prise = 0.8;
                }

                else if (comand == "Coke")
                {
                    prise = 1;

                }

                if (prise != 0)
                {

                    if (curentSum >= prise)
                    {

                        Console.WriteLine($"Purchased {comand.ToLower()}");

                        curentSum -= prise;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }

                else
                {
                    Console.WriteLine($"Invalid product");
                }

                comand = Console.ReadLine();

            }

            Console.WriteLine($"Change: {curentSum:f2}");
        }
    }
}



