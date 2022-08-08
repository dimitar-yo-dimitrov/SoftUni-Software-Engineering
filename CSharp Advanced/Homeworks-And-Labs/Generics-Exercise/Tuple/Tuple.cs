using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<Item1, Item2>
    {
        public Tuple(Item1 nameOfPerson, Item2 nameOfCity)
        {
            NameOfPerson = nameOfPerson;
            NameOfCity = nameOfCity;
        }

        public Item1 NameOfPerson { get; set; }
        public Item2 NameOfCity { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{NameOfPerson} -> {NameOfCity}");

            return sb.ToString().TrimEnd();
        }
    }
}
