using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private int age;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }

        public int Age
        {
            get => this.age;

            protected set
            {
                if (value < 1)
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.age = value;
            }
        }


        public string Gender { get; set; }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }
}
