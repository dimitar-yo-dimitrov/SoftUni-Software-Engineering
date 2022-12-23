namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionersConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AirConditionersConsumption, tankCapacity)
        {
        }
    }
}
