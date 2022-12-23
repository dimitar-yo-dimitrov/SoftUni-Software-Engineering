using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());

            var bulletsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var locksArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            int priceOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArray);
            Queue<int> locks = new Queue<int>(locksArray);

            int barrelsCount = 0;

            while (bullets.Any() && locks.Any())
            {
                int currentBullet = bullets.Peek();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    barrelsCount++;
                    bullets.Pop();
                    locks.Dequeue();
                }

                else
                {
                    Console.WriteLine("Ping!");
                    barrelsCount++;
                    bullets.Pop();
                }

                if (bullets.Any() && barrelsCount % sizeOfGunBarrel == 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

            else
            {
                int totalMoney = barrelsCount * priceOfBullet;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${priceOfIntelligence - totalMoney}");
            }
        }
    }
}
