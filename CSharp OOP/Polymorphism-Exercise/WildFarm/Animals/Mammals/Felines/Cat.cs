using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double WeightIncrease = 0.3;

        public Cat(
            string name,
            double weight, 
            string livingRegion,
            string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProducingSound() 
            => "Meow";

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
            return food == "Meat" || food == "Vegetable"
                ? true
                : throw new ArgumentException($"{GetType().Name} does not eat {food}!");
        }
    }
}
