using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private const double WeightIncrease = 1.0;

        public Tiger(
            string name,
            double weight, 
            string livingRegion,
            string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProducingSound() 
            => "ROAR!!!";

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
