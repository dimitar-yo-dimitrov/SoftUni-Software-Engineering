using PizzaCalories.Exceptions;

using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>()
        {
            { "white", 1.5 },
            { "wholegrain", 1 }

        };

        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>()
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1}
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (!flourTypeCalories.ContainsKey(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughTypeException);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (!bakingTechniqueCalories.ContainsKey(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughTypeException);
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                int rangeMin = (int)Parameters.rangeMin;
                int rangeMax = (int)Parameters.rangeMax;

                if (value< rangeMin || value > rangeMax)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughWeightException);
                }

                this.weight = value;
            }
        }

        public double CalculateCaloriesDough()
            => (double)Parameters.caloriesPerGram * Weight * flourTypeCalories[this.FlourType] *
               bakingTechniqueCalories[this.BakingTechnique];
    }
}
