using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Factories.Contracts
{
    public interface IPlanetFactory
    {
        IPlanet CreatePlanet(string planetName, params string[] items);
    }
}
