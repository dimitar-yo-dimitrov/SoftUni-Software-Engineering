using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box( double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
           this.Height = height;
        }

        public double Length
        {
            get => this.length;
            
            private set
            {
                dataValidation(value, nameof(this.Length));
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
           
            private set
            {
                dataValidation(value, nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            
            private set
            {
                dataValidation(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double SurfaceArea() => 
            2 * length * width + 
            2 * length * height + 
            2 * width * height;

        public double LateralSurfaceArea() 
            => 2 * length * height +
               2 * width * height; 

        public double Volume() 
            => length * width * height;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Surface Area - {SurfaceArea():f2}");
            result.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            result.AppendLine($"Volume - {Volume():f2}");

            return result.ToString().TrimEnd();
        }

        private void dataValidation(double value, string sideName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{sideName} cannot be zero or negative.");
            }
        }
    }
}
