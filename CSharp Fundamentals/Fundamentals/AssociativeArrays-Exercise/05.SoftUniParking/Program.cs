using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            var registeredUsers = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string register = command[0];
                string userName = command[1];

                if (register == "register")
                {
                    string licensePlateNumber = command[2];

                    if (registeredUsers.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                        registeredUsers.Add(userName, licensePlateNumber);
                    }
                }

                else if (register == "unregister")
                {
                    if (registeredUsers.ContainsKey(userName))
                    {
                        Console.WriteLine($"{userName} unregistered successfully");
                        registeredUsers.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
            }

            foreach (var kvp in registeredUsers)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
