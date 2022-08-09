using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Decode")
                {
                    break;
                }

                string[] parts = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(parts[1]);
                    string letters = encryptedMessage.Substring(0, numberOfLetters);
                    encryptedMessage = encryptedMessage.Substring(numberOfLetters) + letters;
                }

                else if (command == "Insert")
                {
                    int index = int.Parse(parts[1]);
                    string character = parts[2];

                    encryptedMessage = encryptedMessage.Insert(index, character);
                }

                else if (command == "ChangeAll")
                {
                    string oldCharacter = parts[1];
                    string newCharacter = parts[2];

                    foreach (var character in encryptedMessage)
                    {
                        encryptedMessage = encryptedMessage.Replace(oldCharacter, newCharacter);
                    }

                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
