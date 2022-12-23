using SpaceStation.Factories.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Factories
{
    public class PlanetFactory : IPlanetFactory
    {
        public IPlanet CreatePlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            return planet;
        }
    }
}
