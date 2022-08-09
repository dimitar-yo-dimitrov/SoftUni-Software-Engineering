namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double FuelAvailable = 80;
        private const double FuelConsumptionPerRace = 10;

        public SuperCar(
            string make, 
            string model, 
            string vin, 
            int horsePower) 
            : base(make, model, vin, horsePower, FuelAvailable, FuelConsumptionPerRace)
        {
        }
    }
}
