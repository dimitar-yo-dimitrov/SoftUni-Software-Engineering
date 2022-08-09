using System.Collections.Generic;
using System.Linq;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
            Models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models { get; private set; }
        

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);

            this.Models = this.decorations;
        }

        public bool Remove(IDecoration model)
        {
            if (this.decorations.Contains(model))
            {
                this.decorations.Remove(model);

                this.Models = this.decorations;

                return true;
            }

            return false;
        }

        public IDecoration FindByType(string type) 
            => this.Models.FirstOrDefault(d => d.GetType().Name == type);
    }
}
