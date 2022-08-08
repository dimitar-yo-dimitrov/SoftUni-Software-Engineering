using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public string Name => name;
        public int Age => age;
        public string Town => town;
        
        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }
           
            if (Age.CompareTo(other.Age) != 0)
            {
                return Age.CompareTo(other.Age);
            }
            
            if (Town.CompareTo(other.Town) != 0)
            {
                return Town.CompareTo(other.Town);
            }

            return 0;
        }
    }
}
