using PizzaCalories.Exceptions;

using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> typesOfToppingCalories = new Dictionary<string, double>()
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}
        };

        private string typesOfTopping;
        private double weight;

        public Topping(string typesOfTopping, double weight)
        {
            this.TypesOfTopping = typesOfTopping;
            this.Weight = weight;
        }

        public string TypesOfTopping
        {
            get => this.typesOfTopping;
           
            private set
            {
                CheckType(value);
                this.typesOfTopping = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            
            private set
            {
                int minWeight = (int)Parameters.minWeight;
                int maxWeight = (int)Parameters.maxWeight;

                CheckWeight(value, minWeight, maxWeight);

                this.weight = value;
            }
        }

        public double CalculateCaloriesTopping()
            => (double)Parameters.caloriesPerGram * weight * typesOfToppingCalories[this.TypesOfTopping];

        private void CheckType(string value)
        {
            if (!typesOfToppingCalories.ContainsKey(value))
            {
                value = value.Remove(1).ToUpper() + value.Substring(1);

                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidToppingTypeException,
                        value));
            }
        }

        private void CheckWeight(double weight, int minWeight, int maxWeight)
        {
            if (weight < minWeight || weight > maxWeight)
            {
                var toppingName = this.TypesOfTopping.Remove(1).ToUpper() + this.TypesOfTopping.Substring(1);

                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidToppingWeightException,
                        toppingName));
            }
        }
    }
}
