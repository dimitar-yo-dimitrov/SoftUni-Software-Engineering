using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "Beast!")
                    {
                        break;
                    }

                    string[] animalInfo = Console.ReadLine().Split();

                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = animalInfo[2];

                    if (input == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }

                    else if (input == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }

                    else if (input == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }

                    else if (input == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }

                    else if (input == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
