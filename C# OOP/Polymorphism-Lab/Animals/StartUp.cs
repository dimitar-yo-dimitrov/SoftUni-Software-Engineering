using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            IAnimal cat = new Cat("Peter", "Whiskas");
            IAnimal dog = new Dog("George", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
