using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> numbers = new HashSet<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = parts[0];
                string carNumber = parts[1];

                numbers.Add(carNumber);

                if (direction == "OUT")
                {
                    numbers.Remove(carNumber);
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
