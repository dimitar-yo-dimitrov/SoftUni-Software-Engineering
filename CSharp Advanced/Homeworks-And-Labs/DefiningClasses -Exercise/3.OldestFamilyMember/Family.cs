using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            Peoples = new List<Person>();
        }

        public List<Person> Peoples { get; set; }
        
        public void AddMember(Person member)
        {
            Peoples.Add(member);
        }

        public Person GetOldestMember()
        {
            return Peoples
                .OrderByDescending(m => m.Age)
                .FirstOrDefault();
        }
    }
}
