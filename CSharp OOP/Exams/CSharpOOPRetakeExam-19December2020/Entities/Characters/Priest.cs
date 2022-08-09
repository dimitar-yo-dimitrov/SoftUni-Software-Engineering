using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer 

    {
        private const double BaseHealthPriest = 50;
        private const double BaseArmorPriest = 25;
        private const double AbilityPointsPriest = 40;

        public Priest(string name) 
            : base(name, BaseHealthPriest, BaseArmorPriest, AbilityPointsPriest, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (base.IsAlive && character.IsAlive)
            {
                character.Health += base.AbilityPoints;
            }
        }
    }
}
