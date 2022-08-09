using System;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaitingLyft = int.Parse(Console.ReadLine());

            int[] wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int peopleOnTheCurentWagon = 0;
            int peopleOnTheLyft = 0;

            bool peopleEnd = false;

            for (int i = 0; i < wagons.Length; i++)
            {
                while (wagons[i] < 4)
                {
                    wagons[i]++;
                    peopleOnTheCurentWagon++;

                    if (peopleOnTheLyft + peopleOnTheCurentWagon == peopleWaitingLyft)
                    {
                        peopleEnd = true;
                        break;
                    }
                }

                peopleOnTheLyft += peopleOnTheCurentWagon;
                
                if (peopleEnd)
                {
                    break;
                }

                peopleOnTheCurentWagon = 0;
            }

            if (peopleWaitingLyft > peopleOnTheLyft)
            {
                int peopleLeft = peopleWaitingLyft - peopleOnTheLyft;
                Console.WriteLine($"There isn't enough space! {peopleLeft} people in a queue!");
                Console.WriteLine(string.Join(' ', wagons));
            }

            else if (peopleWaitingLyft < wagons.Length * 4 && wagons.Any(w => w < 4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            
            else if (wagons.All(w => w == 4) && peopleEnd == true)
            {
                Console.WriteLine(string.Join(' ', wagons));
            }
        }
    }
}
