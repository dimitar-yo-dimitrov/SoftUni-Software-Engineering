using FoodShortage.Contracts;
using FoodShortage.Enums;

namespace FoodShortage.Models
{
    public class Rebel : Person
    {
        public Rebel(string name, int age, string group) 
            : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; private set; }

        public override void BuyFood()
        {
            int increasesFood = (int)IncreasesFood.increasesFoodRebel;

            this.Food += increasesFood;
        }
    }
}
