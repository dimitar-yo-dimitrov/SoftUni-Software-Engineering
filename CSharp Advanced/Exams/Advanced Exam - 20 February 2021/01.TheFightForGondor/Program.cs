using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int countWavesOfOrcs = int.Parse(Console.ReadLine());

            List<int> plates = new List<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Stack<int> orcs = new Stack<int>();

            int countWaves = 0;

            while (plates.Count > 0)
            {
                if (orcs.Count == 0)
                {
                    if (orcs.Count == 0 && countWavesOfOrcs == 0)
                    {
                        break;
                    }

                    countWavesOfOrcs--;
                    countWaves++;

                    int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                    for (int i = 0; i < input.Length; i++)
                    {
                        orcs.Push(input[i]);
                    }

                    if (countWaves == 3)
                    {
                        int newPlate = int.Parse(Console.ReadLine());

                        plates.Add(newPlate);
                        countWaves = 0;
                    }
                }

                var plate = plates.First();
                var orc = orcs.Peek();

                if (plate > orc)
                {
                    orcs.Pop();
                    plates.Remove(plate);
                    plates.Insert(0, plate - orc);
                }
                else if (plate == orc)
                {
                    plates.Remove(plate);
                    orcs.Pop();
                }
                else if (plate < orc)
                {
                    orc -= plate;
                    orcs.Pop();
                    plates.Remove(plate);
                    orcs.Push(orc);
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}
