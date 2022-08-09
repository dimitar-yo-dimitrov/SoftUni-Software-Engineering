using System;

namespace Validator
{
    public class EgnValidator : IEgnValidator
    {
        private string egn;

        public EgnValidator(string egn)
        {
            this.Egn = egn;
        }

        public string Egn
        {
            get => this.egn;
            
            private set
            {
                ValidateEgn(value);

                this.egn = value;
            }
        }

        public bool ValidateEgn(string Egn)
        {
            if (Egn.Length != 10) return false;

            foreach (char digit in Egn)
            {
                if (!Char.IsDigit(digit)) return false;
            }

            var month = int.Parse(Egn.Substring(2, 2));
            var year = 0;

            // Get year before 2000
            if (month < 13)
            {
                year = int.Parse("19" + Egn.Substring(0, 2));
            }

            // Get year before 1900
            else if (month < 33)
            {
                month -= 20;
                year = int.Parse("18" + Egn.Substring(0, 2));
            }

            // Get year after 1999
            else if (month < 53)
            {
                month -= 40;
                year = int.Parse("20" + Egn.Substring(0, 2));
            }

            var day = int.Parse(Egn.Substring(4, 2));

            //GetBirthDayId(day, month, year);

            var weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            var totalControlSum = 0;

            for (int i = 0; i < 9; i++)
            {
                totalControlSum += weights[i] * (Egn[i] - '0');
            }

            var controlDigit = 0;
            var reminder = totalControlSum % 11;

            if (reminder < 10)
            {
                controlDigit = reminder;
            }

            var lastDigitFromIdNumber = int.Parse(Egn.Substring(9));

            if (lastDigitFromIdNumber != controlDigit)
            {
                return false;
            }

            return true;
        }

        private void GetBirthDayId(int day, int month, int year)
        {
            if (!DateTime.TryParse($"{day}/{month}/{year}", out _)) return;
        }
    }
}
