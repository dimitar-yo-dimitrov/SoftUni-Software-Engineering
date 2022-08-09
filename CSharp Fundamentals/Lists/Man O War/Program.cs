using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateChip = Console.ReadLine()
                .Split('>', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> warChip = Console.ReadLine()
                .Split('>', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxHealth = int.Parse(Console.ReadLine());

            bool yes = false;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Retire")
                {
                    break;
                }

                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[0];

                if (comand == "Fire")
                {
                    int idx = int.Parse(parts[1]);
                    int damege = int.Parse(parts[2]);

                    if (idx >= 0 && idx < warChip.Count)
                    {
                        int afterFire = warChip[idx];
                        afterFire = warChip[idx] - damege;

                        if (afterFire <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            yes = true;
                        }
                        else
                        {
                            warChip.RemoveAt(idx);
                            warChip.Insert(idx, afterFire);
                        }
                    }
                }

                else if (comand == "Defend")
                {
                    int startIdx = int.Parse(parts[1]);
                    int endtIdx = int.Parse(parts[2]);
                    int damege = int.Parse(parts[3]);

                    if (startIdx >= 0 && endtIdx < pirateChip.Count)
                    {
                        for (int i = startIdx; i <= endtIdx; i++)
                        {
                            int indexNumber = i;
                            int result = pirateChip[indexNumber] - damege;

                            if (result <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                yes = true;
                                break;
                            }
                            else
                            {
                                pirateChip.Remove(pirateChip[indexNumber]);
                                pirateChip.Insert(startIdx, result);
                                startIdx++;
                            }
                        }
                    }
                }

                else if (comand == "Repair")
                {
                    int idndex = int.Parse(parts[1]);
                    int health = int.Parse(parts[2]);

                    if (idndex >= 0 && idndex < pirateChip.Count)
                    {
                        if (health > maxHealth)
                        {
                            health = maxHealth;

                            pirateChip.RemoveAt(idndex);
                            pirateChip.Insert(idndex, health);
                        }
                        else
                        {
                            int addHealth = pirateChip[idndex];
                            pirateChip.RemoveAt(idndex);
                            pirateChip.Insert(idndex, health + addHealth);
                        }
                    }
                }

                else if (comand == "Status")
                {
                    int count = 0;
                    double procent = maxHealth * 0.2;
                    
                    for (int i = 0; i < pirateChip.Count; i++)
                    {
                        if (procent > pirateChip[i])
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"{count} sections need repair.");
                }

                if (yes)
                {
                    break;
                }
            }

            if (yes == false)
            {
                int pirateShipSum = 0;
                int warshipSum = 0;

                for (int i = 0; i < pirateChip.Count; i++)
                {
                    pirateShipSum += pirateChip[i];
                }

                Console.WriteLine($"Pirate ship status: {pirateShipSum}");

                for (int j = 0; j < warChip.Count; j++)
                {
                    warshipSum += warChip[j];
                }

                Console.WriteLine($"Warship status: {warshipSum}");
            }
        }
    }
}
