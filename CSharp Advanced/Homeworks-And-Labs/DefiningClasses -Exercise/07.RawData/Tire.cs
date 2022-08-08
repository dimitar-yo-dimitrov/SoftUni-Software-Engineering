using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
        
        // {tire1Pressure} {tire1Age}
        
        public double Pressure { get; set; }

        public int Age { get; set; }
    }
}
