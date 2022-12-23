
using BorderControl.Contracts;

namespace BirthdayCelebrations.Models
{
    public class Pet : IIdentifiable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
       
        public string Birthdate { get; private set; }
      
        public string Id { get; }

        public override string ToString()
        {
            return $"{this.Birthdate}";
        }
    }
}
