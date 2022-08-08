using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<Item1, Item2, Item3>
    {
        public Threeuple(Item1 nameOfPerson, Item2 address, Item3 nameOfCity)
        {
            NameOfPerson = nameOfPerson;
            Address = address;
            NameOfCity = nameOfCity;
        }

        public Item1 NameOfPerson { get; set; }

        public Item2 Address { get; set; }

        public Item3 NameOfCity { get; set; }

        public string GetItems()
        {
            return $"{NameOfPerson} -> {Address} -> {NameOfCity}";
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine($"{NameOfPerson} -> {Address} -> {NameOfCity}");

        //    return sb.ToString().TrimEnd();
        //}
    }
}
