using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> races;

        public DriverRepository()
        {
            races = new List<IDriver>();
        }

        public IDriver GetByName(string name) 
            => races.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IDriver> GetAll() 
            => races.ToArray();

        public void Add(IDriver model) 
            => races.Add(model);

        public bool Remove(IDriver model) 
            => races.Remove(model);
    }
}
