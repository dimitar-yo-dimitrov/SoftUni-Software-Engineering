using System;
using System.Collections.Generic;
using WildFarm.Contracts;
using WildFarm.Food;
using WildFarm.Models;

namespace WildFarm
{
    public class Engine
    {
        private readonly List<IAnimal> animals;

        public Engine()
        {
            animals = new List<IAnimal>();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var animalInfo = input.Split();
                var foodInfo = Console.ReadLine().Split();

                try
                {
                    var animal = this.CreateAnimal(animalInfo);
                    var food = this.CreateFood(foodInfo);

                    animals.Add(animal);

                    Console.WriteLine(animal.ProducingSound());
                    animal.Eat(food);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private IFood CreateFood(string[] foodInfo)
        {
            var foodType = foodInfo[0];
            var foodQuantity = int.Parse(foodInfo[1]);


            IFood currentFood = foodType switch
            {
                "Fruit" => new Fruit(foodQuantity),
                "Meat" => new Meat(foodQuantity),
                "Seeds" => new Seeds(foodQuantity),
                "Vegetable" => new Vegetable(foodQuantity),
                _ => null
            };

            return currentFood;
        }

        private IAnimal CreateAnimal(string[] animalInfo)
        {
            var animalType = animalInfo[0];
            var animalName = animalInfo[1];
            var animalWeight = double.Parse(animalInfo[2]);

            IAnimal currentAnimal = null;

            switch (animalType)
            {
                case "Owl":
                    {
                        var wingSize = double.Parse(animalInfo[3]);

                        currentAnimal = new Owl(animalName, animalWeight, wingSize);
                        break;
                    }
                case "Hen":
                    {
                        var wingSize = double.Parse(animalInfo[3]);

                        currentAnimal = new Hen(animalName, animalWeight, wingSize);
                        break;
                    }

                case "Mouse":
                    {
                        var livingRegion = animalInfo[3];

                        currentAnimal = new Mouse(animalName, animalWeight, livingRegion);
                        break;
                    }

                case "Dog":
                    {
                        var livingRegion = animalInfo[3];

                        currentAnimal = new Dog(animalName, animalWeight, livingRegion);
                        break;
                    }
                case "Cat":
                    {
                        var livingRegion = animalInfo[3];
                        var breed = animalInfo[4];

                        currentAnimal = new Cat(animalName, animalWeight, livingRegion, breed);
                        break;
                    }
                case "Tiger":
                    {
                        var livingRegion = animalInfo[3];
                        var breed = animalInfo[4];

                        currentAnimal = new Tiger(animalName, animalWeight, livingRegion, breed);
                        break;
                    }
            }

            return currentAnimal;
        }
    }
}