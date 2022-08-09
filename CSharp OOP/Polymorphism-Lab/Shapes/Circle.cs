using System;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; protected set; }

        public override double CalculatePerimeter() 
            => 2 * this.Radius * Math.PI;

        public override double CalculateArea() 
            => Math.Pow(Radius, 2) * Math.PI;

        public override string Draw() 
            => base.Draw() + GetType().Name;
    }
}
