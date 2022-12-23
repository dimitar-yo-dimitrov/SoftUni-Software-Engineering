using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        private double overallPerformance;
        private decimal price;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();

            OverallPerformance = overallPerformance;
            Price = price;
        }

        public double OverallPerformance { get; }

        public decimal Price { get; }

        public IReadOnlyCollection<IComponent> Components
            => components;

        public IReadOnlyCollection<IPeripheral> Peripherals
            => peripherals;

        public void AddComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                throw new ArgumentException(
                    $"Component {component.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(
                    $"Component {componentType} does not exist in {GetType().Name} with Id {Id}.");
            }

            components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Contains(peripheral))
            {
                throw new ArgumentException(
                    $"Peripheral {peripheral.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException(
                    $"Peripheral  {peripheralType} does not exist in {GetType().Name} with Id {Id}.");
            }

            peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                $"Overall Performance: {OverallPerformance:f2}. Price: " +
                $"{components.Sum(x => x.Price) + peripherals.Sum(x => x.Price):f2} - {GetType().Name}: " + $"{Manufacturer} {Model} (Id: {Id})");

            sb.AppendLine($" Components ({components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine(
                $" Peripherals ({peripherals.Count}); " +
                $"Average Overall Performance ({peripherals.Sum(x => x.OverallPerformance) / peripherals.Count:f2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
