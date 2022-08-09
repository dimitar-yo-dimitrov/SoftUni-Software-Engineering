using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
       
        public int Age { get; set; }
        
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public override string ToString()
        {
            return $"{this.Birthdate}";
        }
    }
}
