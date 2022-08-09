using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => (IReadOnlyCollection<IPlanet>)planets;

        public void Add(IPlanet planet)
            => this.planets.Add(planet);

        public bool Remove(IPlanet planet)
            => this.planets.Remove(planet);

        public IPlanet FindByName(string name)
            => planets.FirstOrDefault(a => a.Name == name);
    }
}
