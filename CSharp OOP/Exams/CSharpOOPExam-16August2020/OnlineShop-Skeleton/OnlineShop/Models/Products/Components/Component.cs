using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                $"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {GetType().Name}: " +
                $"{Manufacturer} {Model} (Id: {Id}) Generation: {Generation}");

            return sb.ToString().TrimEnd();
        }
    }
}
