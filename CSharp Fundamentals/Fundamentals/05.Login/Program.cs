using System;
using System.Linq;
namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Concat(username.Reverse());

            bool isLogedIn = false;

            int count = 0;

            while (!isLogedIn)
            {
                string login = Console.ReadLine();

                count++;

                if (login != password && count == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    isLogedIn = true;
                }

                else if (login == password)
                {
                    Console.WriteLine($"User {username} logged in.");

                    isLogedIn = true;
                }

                else if (login != password)
                {
                    Console.WriteLine($"Incorrect password. Try again.");
                }
            }
        }
    }
}
