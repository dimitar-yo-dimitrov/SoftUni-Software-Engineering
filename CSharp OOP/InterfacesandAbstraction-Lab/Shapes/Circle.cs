using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius
        {
            get => this.radius;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException
                        (nameof(value), "must be zero or non negative");
                }

                this.radius = value;
            }
        }

        public void Draw()
        {
            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;
            var symbol = '*';

            for (double y = this.radius; y >= -this.radius; --y)
            {

                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }

                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}