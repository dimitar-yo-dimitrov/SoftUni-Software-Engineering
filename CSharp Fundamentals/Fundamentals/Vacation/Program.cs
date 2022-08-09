using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countGroup = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string day = Console.ReadLine();


            double price = 0;
            double totalPrice = 0;

            if (group == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;

                    totalPrice = price * countGroup;

                    if (countGroup >= 30)
                    {
                        totalPrice *= 0.85;
                    }
                }

                else if (day == "Saturday")
                {
                    price = 9.80;

                    totalPrice = price * countGroup;

                    if (countGroup >= 30)
                    {
                        totalPrice *= 0.85;
                    }
                }

                else if (day == "Sunday")
                {
                    price = 10.46;

                    totalPrice = price * countGroup;

                    if (countGroup >= 30)
                    {
                        totalPrice *= 0.85;
                    }
                }

            }

            else if (group == "Business")

            {
                if (day == "Friday")
                {
                    price = 10.90;

                    if (countGroup >= 100)
                    {
                        countGroup -= 10;
                    }

                    totalPrice = price * countGroup;
                }

                else if (day == "Saturday")
                {
                    price = 15.60;

                    if (countGroup >= 100)
                    {
                        countGroup -= 10;
                    }

                    totalPrice = price * countGroup;
                }

                else if (day == "Sunday")
                {
                    price = 16;


                    if (countGroup >= 100)
                    {
                        countGroup -= 10;
                    }

                    totalPrice = price * countGroup;
                }
            }

            else if (group == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;

                    totalPrice = price * countGroup;

                    if (countGroup >= 10 && countGroup <= 20)
                    {
                        totalPrice *= 0.95;
                    }
                }

                else if (day == "Saturday")
                {
                    price = 20;

                    totalPrice = price * countGroup;

                    if (countGroup >= 10 && countGroup <= 20)
                    {
                        totalPrice *= 0.95;
                    }
                }

                else if (day == "Sunday")
                {
                    price = 22.50;

                    totalPrice = price * countGroup;

                    if (countGroup >= 10 && countGroup <= 20)
                    {
                        totalPrice *= 0.95;
                    }
                }

            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
