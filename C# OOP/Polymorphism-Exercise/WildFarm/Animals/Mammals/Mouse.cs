using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double WeightIncrease = 0.1;

        public Mouse(
            string name,
            double weight, 
            string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProducingSound() 
            => "Squeak";

        public override string ToString() 
            => $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";

        public override void Eat(IFood food)
        {
            if (ValidateFood(food.GetType().Name))
            {
                Weight += food.Quantity * WeightIncrease;

                FoodEaten += food.Quantity;
            }
        }

        private bool ValidateFood(string food)
        {
            return food == "Fruit" || food == "Vegetable"
                ? true
                : throw new ArgumentException($"{GetType().Name} does not eat {food}!");
        }
    }
}
