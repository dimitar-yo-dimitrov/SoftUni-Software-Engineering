namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int CapacityDefaultValue = 20;

        public Satchel()
            : base(CapacityDefaultValue)
        {
        }
    }
}
