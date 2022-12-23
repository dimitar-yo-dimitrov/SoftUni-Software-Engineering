namespace WildFarm.Contracts
{
    public interface IAnimal
    {
        public string Name { get; }

        
        public double Weight { get; }

        public int FoodEaten { get; }

        public string ProducingSound();

        public void Eat(IFood food);
    }
}
