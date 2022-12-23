using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double FuelAvailable = 65;
        private const double FuelConsumptionPerRace = 7.5;

        public TunedCar(
            string make, 
            string model, 
            string vin, 
            int horsePower) 
            : base(make, model, vin, horsePower, FuelAvailable, FuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();

            this.HorsePower = (int)Math.Round(this.HorsePower * 0.97);
        }
    }
}
