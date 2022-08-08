using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            int dippingSauce = 0, greenSalad = 0, chocolateCake = 0, lobster = 0;

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                var ingredient = ingredients.Peek();
                var fresh = freshness.Peek();
                var freshnessLevel = ingredient * fresh;

                if (freshnessLevel == 150)
                {
                    dippingSauce++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }

                else if (freshnessLevel == 250)
                {
                    greenSalad++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }

                else if (freshnessLevel == 300)
                {
                    chocolateCake++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }

                else if (freshnessLevel == 400)
                {
                    lobster++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }

                else if (ingredient == 0)
                {
                    ingredients.Dequeue();
                }

                else
                {
                    freshness.Pop();
                    ingredient += 5;
                    ingredients.Dequeue();
                    ingredients.Enqueue(ingredient);
                }
            }

            if (dippingSauce > 0 && greenSalad > 0 && chocolateCake > 0 && lobster > 0)
            {
                // Applause! The judges are fascinated by your dishes!
                // # Chocolate cake --> 2
                // # Dipping sauce --> 2
                // # Green salad --> 1
                // # Lobster --> 1

                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
                Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
                Console.WriteLine($"# Dipping sauce --> {dippingSauce}");
                Console.WriteLine($"# Green salad --> {greenSalad}");
                Console.WriteLine($"# Lobster --> {lobster}");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");

                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }

                if (chocolateCake != 0)
                {
                    Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
                }

                if (dippingSauce != 0)
                {
                    Console.WriteLine($"# Dipping sauce --> {dippingSauce}");
                }

                if (greenSalad != 0)
                {
                    Console.WriteLine($"# Green salad --> {greenSalad}");
                }

                if (lobster != 0)
                {
                    Console.WriteLine($"# Lobster --> {lobster}");
                }
            }
        }
    }
}