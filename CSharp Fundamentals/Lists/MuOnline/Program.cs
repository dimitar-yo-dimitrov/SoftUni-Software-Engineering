using System;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            int health = 100;
            int bitcoins = 0;
            int bestRoom = 0;
            bool isValid = true;
            //int takeHealth = 0;

            for (int i = 0; i < rooms.Length; i++)
            {

                string comand = rooms[i];

                string[] parts = comand
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                bestRoom++;

                if (parts[0] == "potion")
                {
                    int curentHealth = health;
                    int takeHealth = int.Parse(parts[1]);
                    health += takeHealth;

                    if (health > 100)
                    {
                        health = 100;
                        takeHealth = health - curentHealth;
                    }
                    Console.WriteLine($"You healed for {takeHealth} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }

                else if (parts[0] == "chest")
                {
                    int foundedBitcoins = int.Parse(parts[1]);
                    bitcoins += foundedBitcoins;

                    Console.WriteLine($"You found {foundedBitcoins} bitcoins.");
                }

                else
                {
                    //int curentHealth = health;
                    int monsterAtack = int.Parse(parts[1]);
                    health -= monsterAtack;


                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {parts[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {parts[0]}.");
                        Console.WriteLine($"Best room: {bestRoom}");
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
