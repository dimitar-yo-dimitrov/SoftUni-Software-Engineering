using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IRace GetByName(string name)
            => races.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRace> GetAll()
            => races.ToArray();

        public void Add(IRace model)
            => races.Add(model);

        public bool Remove(IRace model)
            => races.Remove(model);
    }
}
