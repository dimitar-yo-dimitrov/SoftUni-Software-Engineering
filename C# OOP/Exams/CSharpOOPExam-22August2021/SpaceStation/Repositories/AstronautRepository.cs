using System.Linq;

namespace SpaceStation.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models 
            => (IReadOnlyCollection<IAstronaut>)astronauts;

        public void Add(IAstronaut planet) 
            => this.astronauts.Add(planet);

        public bool Remove(IAstronaut astronaut) 
            => this.astronauts.Remove(astronaut);

        public IAstronaut FindByName(string name)
            => astronauts.FirstOrDefault(a => a.Name == name);
    }
}
