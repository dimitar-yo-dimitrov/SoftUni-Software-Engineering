using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            int totalCarsPassed = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line.StartsWith("END"))
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "green")
                {
                    int greenLight = durationOfGreenLight;
                    int windowInSeconds = freeWindow;

                    while (carsQueue.Any())
                    {
                        string currentCar = carsQueue.Peek();

                        if (greenLight >= currentCar.Length)
                        {
                            greenLight -= currentCar.Length;
                            carsQueue.Dequeue();
                            totalCarsPassed++;
                        }

                        else if (greenLight <= 0)
                        {
                            break;
                        }

                        else if (greenLight < currentCar.Length)
                        {
                            if (greenLight + windowInSeconds >= currentCar.Length)
                            {
                                greenLight = 0;
                                windowInSeconds -= currentCar.Length;
                                carsQueue.Dequeue();
                                totalCarsPassed++;
                            }

                            else
                            {
                                int indexOfCrash = greenLight + windowInSeconds;

                                if (indexOfCrash >= 0 && indexOfCrash < currentCar.Length)
                                {
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[indexOfCrash]}.");
                                    return;
                                }
                            }
                        }
                    }
                }

                else
                {
                    carsQueue.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
