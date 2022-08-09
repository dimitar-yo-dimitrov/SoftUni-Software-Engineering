using System;
using Telephony.Contracts;
using Telephony.Models;

namespace Telephony
{
    public class Engine
    {
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            ICallable call = null;

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        call = new StationaryPhone();
                    }

                    else if (phoneNumber.Length == 10)
                    {
                        call = new Smartphone();
                    }

                    call.Call(phoneNumber);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }

            foreach (var website in websites)
            {
                try
                {
                    IBrowsable browsing = new Smartphone();

                    browsing.Browsing(website);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }
        }
    }
}