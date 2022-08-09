using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Contracts;

namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name)
        {
           this.Name = name;
        }

        public string Name { get; set; }

        public virtual int Power { get; set; }

        public virtual string CastAbility()
        {
            return null;
        }
    }
}
