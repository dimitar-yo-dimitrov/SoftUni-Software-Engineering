using Raiding.Enumerations;

namespace Raiding.Models
{
    public class Warrior : BaseHero 
    {
        public Warrior(string name) 
            : base(name)
        {
        }

        public override int Power => (int)HeroPower.WarriorPower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
