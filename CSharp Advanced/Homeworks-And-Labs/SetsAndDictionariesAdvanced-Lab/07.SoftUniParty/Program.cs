using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string name = Console.ReadLine();

            while (name != "PARTY")
            {
                char first = name[0];

                if (name.Length == 8 && char.IsDigit(first))
                {
                    vip.Add(name);
                }
                else
                {
                    regular.Add(name);
                }

                name = Console.ReadLine();
            }

            while (true)
            {
                name = Console.ReadLine();

                if (name == "END")
                {
                    break;
                }

                if (vip.Contains(name))
                {
                    vip.Remove(name);
                }
                else
                {
                    regular.Remove(name);
                }
            }

            Console.WriteLine(vip.Count + regular.Count);

            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }

        }
    }
}
