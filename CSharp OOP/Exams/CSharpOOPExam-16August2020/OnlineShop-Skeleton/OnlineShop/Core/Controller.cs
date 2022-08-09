using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer comp;

            var computer = computers.FirstOrDefault(x => x.Id == id);

            if (computer != null)
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            switch (computerType)
            {
                case "DesktopComputer":
                    comp = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case "Laptop":
                    comp = new Laptop(id, manufacturer, model, price);
                    break;
                default:
                    throw new ArgumentException("Computer type is invalid.");
            }

            computers.Add(comp);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IPeripheral peripheral;

            var computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var peripheralExist = peripherals.FirstOrDefault(x => x.Id == id);

            if (peripheralExist != null)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            switch (peripheralType)
            {
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException("Peripheral type is invalid.");
            }

            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IPeripheral peripheralToRemove = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            var computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            foreach (var item in computers)
            {
                if (item.Id == computerId)
                {
                    item.RemovePeripheral(peripheralType);
                }
            }

            peripherals.Remove(peripheralToRemove);

            return $"Successfully removed {peripheralType} with id {peripheralToRemove.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            IComponent component;

            var computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var componentExist = components.FirstOrDefault(x => x.Id == id);

            if (componentExist != null)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            switch (componentType)
            {
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException("Component type is invalid.");
            }

            computer.AddComponent(component);
            components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var componentToRemove = components.FirstOrDefault(x => x.GetType().Name == componentType);

            var computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            computer.RemoveComponent(componentType);
            components.Remove(componentToRemove);

            return $"Successfully removed {componentType} with id {componentToRemove.Id}.";
        }

        public string BuyComputer(int id)
        {
            var comp = computers.FirstOrDefault(x => x.Id == id);

            if (comp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            computers.Remove(comp);
            return comp.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var maxPerformance = components.Max(x => x.OverallPerformance);

            IComputer comp = computers.FirstOrDefault(x => x.OverallPerformance == maxPerformance);

            if (comp == null || comp.Price > budget)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            computers.Remove(comp);

            return comp.ToString().TrimEnd();
        }

        public string GetComputerData(int id)
        {
            var computer = computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString().TrimEnd();
        }
    }
}
