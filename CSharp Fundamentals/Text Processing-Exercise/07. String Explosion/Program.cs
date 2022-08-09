using System;
using System.Linq;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());

                    result.Append(symbol);
                }

                else if (strength > 0)
                {
                    strength -= 1;
                }
                else
                {
                    result.Append(symbol);
                }
            }

            Console.WriteLine(result);
        }
    }
}
