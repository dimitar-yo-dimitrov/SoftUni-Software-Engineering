using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private const int DecreaseEnergy = 10;

        private string name;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;

            this.Dyes = new List<IDye>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidBunnyName);
                }


                this.name = value;
            }
        }

        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes { get; }

        public virtual void Work()
        {
            this.Energy -= DecreaseEnergy;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
            else
            {
                while (Dyes.Any())
                {
                    if (Dyes.First().IsFinished() == false)
                    {
                        Dyes.First().Use();
                        break;
                    }

                    Dyes.Remove(Dyes.First());
                }
            }
        }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }
    }
}
