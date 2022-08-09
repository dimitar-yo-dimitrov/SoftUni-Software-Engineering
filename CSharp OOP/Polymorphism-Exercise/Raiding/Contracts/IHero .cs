namespace Raiding.Contracts
{
    public interface IHero
    {
        public string Name { get; set; }
        
        string CastAbility();
    }
}
