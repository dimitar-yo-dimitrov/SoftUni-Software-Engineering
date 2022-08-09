using System;

namespace Validator
{
    public class Program
    {
        public static void Main()
        {
                var personalIdNumber = Console.ReadLine();

                IValidatorIdNumber validator = new ValidatorIdNumber(personalIdNumber);

                Console.WriteLine(validator.ValidatePersonalIdNumber(personalIdNumber)
                    ? $"ID-{personalIdNumber} is correct"
                    : $"ID-{personalIdNumber} is not correct");
        }
    }
}
