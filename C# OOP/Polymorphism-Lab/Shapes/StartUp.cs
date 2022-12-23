using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle(3.0, 4.0);
            Circle circle = new Circle(3.0);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculateArea()); // 12
            Console.WriteLine(rectangle.CalculatePerimeter()); // 24
            
            Console.WriteLine(circle.Draw());
            Console.WriteLine(circle.CalculateArea()); // 28.274333882308138
            Console.WriteLine(circle.CalculatePerimeter()); // 18.84955592153876
        }
    }
}
