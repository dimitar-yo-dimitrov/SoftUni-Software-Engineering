using System.Collections.Generic;
using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnies;

        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models { get; private set; } 
            = new List<IBunny>();
        

        public void Add(IBunny bunny)
        {
            this.bunnies.Add(bunny);

            Models = bunnies;
        }
       
        public IBunny FindByName(string name)
            => this.bunnies.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny bunny)
        {
            if (bunnies.Contains(bunny))
            {
                bunnies.Remove(bunny);

                Models = bunnies;

                return true;
            }

            return false;
        } 
    }
}
