using System;

namespace Validator
{
    public class Program
    {
        public static void Main()
        {
                var egn = Console.ReadLine();

                IEgnValidator validator = new EgnValidator(egn);

                Console.WriteLine(validator.ValidateEgn(egn)
                    ? $"Egn-{egn} is correct"
                    : $"Egn-{egn} is not correct");
        }
    }
}
