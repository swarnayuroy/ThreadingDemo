using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadingDemo1
{
    abstract class Shape
    {
        protected double length, width;        
        public abstract void CalculateArea();
        public abstract void CalculatePerimeter();
    }

    class Square : Shape
    {
        public Square(double length)
        {
            this.length = length;
        }
        public override void CalculateArea()
        {
            Console.WriteLine($"Area of the square : {length * length} cmsq") ;
        }

        public override void CalculatePerimeter()
        {
            Console.WriteLine($"Perimeter of the square : {length * 4} cm");
        }
    }
    class Rectangle : Shape
    {
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public override void CalculateArea()
        {
            Console.WriteLine($"Area of the rectangle : {Math.Round(length*width, 2)} cmsq");
        }

        public override void CalculatePerimeter()
        {
            double perimeter = 2 * (length + width);
            Console.WriteLine($"Perimeter of the rectangle : {perimeter} cm");
        }
    }
    class Circle : Shape
    {
        public Circle(double radius)
        {
            this.length = radius;
        }
        public override void CalculateArea()
        {
            Console.WriteLine($"Area of the circle : {Math.Round(3.14 * length * length, 2)} cmsq");
        }
        public override void CalculatePerimeter()
        {
            Console.WriteLine($"Circumference of the circle : {Math.Round(2 * 3.14 * length, 2)} cm");
        }
    }
}
