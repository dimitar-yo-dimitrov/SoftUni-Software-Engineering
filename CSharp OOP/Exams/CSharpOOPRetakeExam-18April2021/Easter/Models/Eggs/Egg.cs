using System;
using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private const int DecreaseEnergyRequired = 10;

        private string name;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidEggName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired { get; private set; }

        public void GetColored()
        {
            this.EnergyRequired -= DecreaseEnergyRequired;

            if (this.EnergyRequired < 0)
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            return this.EnergyRequired == 0;
        }
    }
}
