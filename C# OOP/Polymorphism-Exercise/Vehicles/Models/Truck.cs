namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionersConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity,
                fuelConsumption + AirConditionersConsumption,
                tankCapacity)
        {
        }
    }
}
