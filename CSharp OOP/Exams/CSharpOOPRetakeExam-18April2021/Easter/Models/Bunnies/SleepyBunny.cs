using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int DecreaseEnergy = 5;
        private const int InitialEnergy = 50;

        public SleepyBunny(string name)
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= DecreaseEnergy;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }

            base.Work();
        }
    }
}
