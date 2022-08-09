using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; protected set; }
        
        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string ProducingSound();

        public abstract void Eat(IFood food);
    }
}
