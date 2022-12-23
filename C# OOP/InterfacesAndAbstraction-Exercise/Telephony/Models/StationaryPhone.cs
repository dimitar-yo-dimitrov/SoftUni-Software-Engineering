using System;
using System.Linq;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            if (number.Any(char.IsLetter))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
