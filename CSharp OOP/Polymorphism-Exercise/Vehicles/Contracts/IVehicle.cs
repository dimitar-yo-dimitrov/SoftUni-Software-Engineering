namespace Vehicles.Contracts
{
    interface IVehicle
    {
        public double FuelQuantity { get; }
       
        public double FuelConsumption { get; set; }

        public double TankCapacity { get; }

        void Drive(double distance);
       
        void Refuel(double fuel);
    }
}
