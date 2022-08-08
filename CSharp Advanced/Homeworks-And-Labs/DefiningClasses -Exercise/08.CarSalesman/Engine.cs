using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        /*
        •	Model
        •	Power
        •	Displacement
        •	Efficiency
        */

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;

        }

        public Engine(string model, int power, int displacement)
         : this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
         : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
         : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int? Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string displacement = Displacement.HasValue
                ? Displacement.ToString()
                : "n/a";

            string efficiency = Efficiency ?? "n/a";

            //string efficiency = string.IsNullOrEmpty(this.Efficiency)
            //    ? "n/a"
            //    : this.Efficiency;

            result
                .AppendLine($"{Model}:")
                .AppendLine($"Power: {Power}")
                .AppendLine($"Displacement: {displacement}")
                .AppendLine($"Efficiency: {efficiency}");

            return result.ToString().TrimEnd();
        }
    }
}
