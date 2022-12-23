using PizzaCalories.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                int maxSymbols = (int)Parameters.maxSymbols;
                int minSymbols = (int)Parameters.minSymbols;

                CheckName(value, maxSymbols, minSymbols);

                this.name = value;
            }
        }

        public Dough Dough { get; private set; }

        public IReadOnlyCollection<Topping> Toppings
            => toppings;

        public int ToppingsCount => this.toppings.Count;

        public void AddTopping(Topping topping)
        {
            int maxNumberOfToppings = (int)Parameters.maxNumberOfToppings;

            CheckNumberOfCount(ToppingsCount, maxNumberOfToppings);

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
          var totalCalories =
                Dough.CalculateCaloriesDough() + this.toppings.Sum(x => x.CalculateCaloriesTopping());
            
            return $"{this.Name.Remove(1).ToUpper() + this.Name.Substring(1)} - {totalCalories:F2} Calories.";
        }

        private void CheckNumberOfCount(int toppingsCount, int maxNumberOfToppings)
        {
                if (toppingsCount > maxNumberOfToppings)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidNumberOfToppingsException);
                }
        }

        private void CheckName(string value, int maxSymbols, int minSymbols)
        {
            if (string.IsNullOrEmpty(value) || 
                value.Length < minSymbols || 
                value.Length > maxSymbols)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidPizzaNameException);
            }
        }
    }
}
