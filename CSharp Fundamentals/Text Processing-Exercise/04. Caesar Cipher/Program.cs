using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (var leter in text)
            {
                char encryptedLeter = (char)(leter + 3);

                sb.Append(encryptedLeter);
            }

            Console.WriteLine(sb);
        }
    }
}
