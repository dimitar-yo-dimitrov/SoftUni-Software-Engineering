using System;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const double DecreaseTruckFuelQuantity = 0.95;

        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            protected set
            {
                this.fuelQuantity = value > this.TankCapacity ? 0 : value;
            }
        }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public virtual void Drive(double distance)
        {
            var amountOfConsumption = distance * (this.FuelConsumption);

            if (amountOfConsumption <= this.FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

                this.FuelQuantity -= amountOfConsumption;
            }

            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            var fuelAmount = this.FuelQuantity + fuel;

            if (fuelAmount > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }

            else
            {
                if (this.GetType().Name == "Truck")
                {
                    this.FuelQuantity += fuel * DecreaseTruckFuelQuantity;
                }

                else
                {
                    this.FuelQuantity += fuel;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
