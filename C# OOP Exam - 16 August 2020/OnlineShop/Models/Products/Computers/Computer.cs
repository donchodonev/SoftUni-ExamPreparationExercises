using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components { get => this.components.AsReadOnly(); }

        public IReadOnlyCollection<IPeripheral> Peripherals { get => this.peripherals.AsReadOnly(); }

        public override double OverallPerformance
        {
            get
            {
                if (Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + Components.Average(x => x.OverallPerformance);
                }
            }
        }

        public override decimal Price
        {
            get => base.Price + Components.Sum(x => x.Price) + Peripherals.Sum(x => x.Price);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {OverallPerformance:F2}. Price: {Price:F2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})");

            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine($"  {component}");
            }

            if (Peripherals.Count == 0)
            {
                sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({0.00}):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(x => x.OverallPerformance):F2}):");
            }

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            if (Components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = Components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (Components.Count == 0 || component == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (Peripherals.Count == 0 || peripheral == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            peripherals.Remove(peripheral);

            return peripheral;
        }
    }
}
