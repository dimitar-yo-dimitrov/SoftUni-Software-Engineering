using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person();

            //person.Name = "Gosho";
            //person.Age = 45;

            Console.WriteLine($"{person.Name} \n{person.Age}");
        }
    }
}
