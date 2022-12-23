using System.Collections.Generic;
using System.Linq;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models { get; private set; } 
            = new List<IEgg>();

        public void Add(IEgg model)
        {

            this.eggs.Add(model);

            Models = eggs;
        }

        public bool Remove(IEgg model)
        {
            if (eggs.Contains(model))
            {
                eggs.Remove(model);

                Models = eggs;

                return true;
            }

            return false;
        }

        public IEgg FindByName(string name) 
            => this.eggs.FirstOrDefault(e => e.Name == name);
    }
}
