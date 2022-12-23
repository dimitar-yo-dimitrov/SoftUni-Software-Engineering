using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> reces;

        public CarRepository()
        {
            reces = new List<ICar>();
        }

        public ICar GetByName(string name)
            => reces.FirstOrDefault(x => x.Model == name);

        public IReadOnlyCollection<ICar> GetAll()
            => reces.ToArray();

        public void Add(ICar model)
            => reces.Add(model);

        public bool Remove(ICar model)
            => reces.Remove(model);
    }
}
