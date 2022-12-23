using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const double WeightIncrease = 0.25;

        public Owl(
            string name,
            double weight,
            double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override string ProducingSound() 
            => "Hoot Hoot";

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
            return food == "Meat"
                ? true
                : throw new ArgumentException($"{GetType().Name} does not eat {food}!");
        }
    }
}
