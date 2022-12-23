using System;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().ToLower().Split();
                string[] doughInfo = Console.ReadLine().ToLower().Split();

                string pizzaName = pizzaInfo[1];
                string doughFlourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double doughWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughFlourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingInfo = Console.ReadLine().ToLower();

                while (toppingInfo != "end")
                {
                    string[] parts = toppingInfo.Split();

                    string type = parts[1];
                    double weight = double.Parse(parts[2]);

                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);

                    toppingInfo = Console.ReadLine().ToLower();
                }
                
                Console.WriteLine(pizza);
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
