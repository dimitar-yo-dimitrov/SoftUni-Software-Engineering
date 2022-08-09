using System;

using System.Linq;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {

            //string password = string.Concat(username.Reverse());

            var input = Console.ReadLine();

            string comand = string.Concat(input.Reverse());

            Console.WriteLine(comand);
        }
    }
}
