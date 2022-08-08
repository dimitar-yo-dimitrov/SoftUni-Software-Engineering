using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name, int badges = 0)
        {
            Name = name;
            Badges = badges;
            Pokemons = new List<Pokemon>();
        }

        //•	Name
        //•	Number of badges
        //•	A collection of pokemon

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
