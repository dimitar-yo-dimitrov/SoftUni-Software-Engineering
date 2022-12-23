using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, double weight)
         : this(model, engine)
        {
            Weight = weight;
        }
        public Car(string model, Engine engine, string color)
         : this(model, engine)
        {
            Color = color;
        }
        public Car(string model, Engine engine, double weight, string color)
         : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        /*
        •	Model
        •	Engine
        •	Weight 
        •	Color
        */

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double? Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string weight = Weight.HasValue
                ? Weight.ToString()
                : "n/a";

            string color = string.IsNullOrEmpty(this.Color)
                ? "n/a"
                : this.Color;

            result
                .AppendLine($"{Model}:")
                .AppendLine($"{Engine}")
                .AppendLine($"Weight: {weight}")
                .AppendLine($"Color: {color}");

            return result.ToString().TrimEnd();
        }
    }
}
