namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int DecreaseOxygen = 5;
        private const int InitialOxygen = 70;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - DecreaseOxygen > 0)
            {
                this.Oxygen -= DecreaseOxygen;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
