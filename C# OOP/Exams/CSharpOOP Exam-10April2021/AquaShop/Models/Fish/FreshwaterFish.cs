namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Decorations.Fish
    {
        private const int InitialSize = 3;
        private const int IncreasesSize = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = InitialSize;
        }

        public override void Eat()
        {
            this.Size += IncreasesSize;
        }
    }
}
