using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Factories.Contracts
{
    public interface IAstronautFactory
    {
        IAstronaut CreateAstronaut(string type, string astronautName);
    }
}
