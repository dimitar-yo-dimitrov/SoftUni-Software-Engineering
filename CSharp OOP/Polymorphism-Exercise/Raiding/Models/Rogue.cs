using Raiding.Enumerations;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) 
            : base(name)
        {
        }

        public override int Power => (int)HeroPower.RoguePower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
