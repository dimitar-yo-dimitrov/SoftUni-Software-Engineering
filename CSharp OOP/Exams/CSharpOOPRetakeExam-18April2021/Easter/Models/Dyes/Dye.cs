using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private const int DecreasePower = 10;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power { get; private set; }

        public void Use()
        {
            this.Power -= DecreasePower;

            if (this.Power < 0)
            {
                this.Power = 0;
            }
        }

        public bool IsFinished()
        {
            return this.Power == 0;
        }
    }
}
