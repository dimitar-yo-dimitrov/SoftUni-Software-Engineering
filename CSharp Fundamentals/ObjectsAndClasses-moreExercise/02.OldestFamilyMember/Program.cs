using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        //public Person()
        //{
        //    this.Name = "No name";
        //    this.Age = 1;
        //}

        //public Person(int age)
        //{
        //    this.Name = "No name";
        //    this.Age = age;
        //}

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    public class Family
    {
        private List<Person> peoples;

        public List<Person> Peoples
        {
            get { return peoples; }
            set { peoples = value; }
        }

        public Family()
        {
            this.Peoples = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.Peoples.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.Peoples
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] familyData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var person = new Person(familyData[0], int.Parse(familyData[1]));

                persons.AddMember(person);
            }

            var oldestMember = persons.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}   
