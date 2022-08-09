using System;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                if (IsValid(name))
                {
                    Console.WriteLine(name);
                }
            }
        }

        private static bool IsValid(string name)
        {
            return IsValidLenght(name) && ContainsValidSymbol(name);
        }

        private static bool ContainsValidSymbol(string name)
        {
            foreach (var symbol in name)
            {
                if (!char.IsLetterOrDigit(symbol) &&
                    symbol != '-' && 
                    symbol != '_')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidLenght(string name)
        {
                return name.Length >= 3 && name.Length <= 16;
        }
    }
}
