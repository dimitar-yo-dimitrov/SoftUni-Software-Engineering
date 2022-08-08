using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //{ first name}{ last name}{ address}

            var firstPersonData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = $"{firstPersonData[0]} {firstPersonData[1]}";
            var address = firstPersonData[2];

            // {name} {liters of beer}

            var secondPersonData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var personName = secondPersonData[0];
            var amountOfBeer = int.Parse(secondPersonData[1]);

            // {integer} {double}

            var thirdPersonData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var integer = int.Parse(thirdPersonData[0]);
            var doubleDigit = double.Parse(thirdPersonData[1]);
           
            var nameAndAddress = new Tuple<string, string>(name, address);
            var nameAndAmountOfBeer = new Tuple<string, int>(personName, amountOfBeer);
            var numbers = new Tuple<int, double>(integer, doubleDigit);

            Console.WriteLine(nameAndAmountOfBeer);
            Console.WriteLine(nameAndAddress);
            Console.WriteLine(numbers);
        }
    }
}
