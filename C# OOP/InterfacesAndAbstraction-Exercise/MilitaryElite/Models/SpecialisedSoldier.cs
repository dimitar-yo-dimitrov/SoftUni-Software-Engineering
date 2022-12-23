using System;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        private string corps;

        public SpecialisedSoldier(
            string id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => corps;
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid Corps!");
                }

                corps = value;
            }
        }

        public override string ToString() 
            => $"{base.ToString()}{Environment.NewLine}Corps: {this.Corps}";
    }
}
