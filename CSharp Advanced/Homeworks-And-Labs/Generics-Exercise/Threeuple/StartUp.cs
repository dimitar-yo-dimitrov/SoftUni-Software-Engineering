using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // {first name last name} {address} {town}

            var firstPersonData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = $"{firstPersonData[0]} {firstPersonData[1]}";
            var address = firstPersonData[2];
            var town = string.Join(" ", firstPersonData.Skip(3));

            // {name} {liters of beer} {drunk or not}

            var secondPersonData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var personName = secondPersonData[0];
            var amountOfBeer = int.Parse(secondPersonData[1]);
            bool drunk = DrunkOrNot(secondPersonData[2]);

            // {name} {account balance} {bank name}

            var thirdPersonData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var nameFirst = thirdPersonData[0];
            var accountBalance = double.Parse(thirdPersonData[1]);
            var bankName = thirdPersonData[2];

            var nameAndAmountOfBeer = new Threeuple<string, int, bool>(personName, amountOfBeer, drunk);
            var personInfo = new Threeuple<string, string, string>(name, address, town);
            var bankInfo = new Threeuple<string, double, string>(nameFirst, accountBalance, bankName);

            Console.WriteLine(personInfo.GetItems());
            Console.WriteLine(nameAndAmountOfBeer.GetItems());
            Console.WriteLine(bankInfo.GetItems());
        }

        private static bool DrunkOrNot(string drunk)
        {
            if (drunk == "drunk")
            {
                return true;
            }

            return false;
        }
    }
}
