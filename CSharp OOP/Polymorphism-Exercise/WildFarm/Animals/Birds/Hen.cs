using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const double WeightIncrease = 0.35;

        public Hen(
            string name,
            double weight, 
            double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProducingSound() 
            => "Cluck";

        public override void Eat(IFood food)
        {
            Weight += food.Quantity * WeightIncrease;

            FoodEaten += food.Quantity;
        }
    }
}
