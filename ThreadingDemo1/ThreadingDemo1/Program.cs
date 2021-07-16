using System;
using System.Threading;

namespace ThreadingDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape square = new Square(12.5);
            Shape rectangle = new Rectangle(12.5, 8.8);
            Shape circle = new Circle(10.9);

            //Square Thread
            Thread squareArea = new Thread(square.CalculateArea);
            Thread squarePerimeter = new Thread(square.CalculatePerimeter);

            //Rectangle Thread
            Thread rectangleArea = new Thread(rectangle.CalculateArea);
            Thread rectanglePerimeter = new Thread(rectangle.CalculatePerimeter);

            //Circle Thread
            Thread circleArea = new Thread(circle.CalculateArea);
            Thread circlePerimeter = new Thread(circle.CalculatePerimeter);

            //Thread Execution
            squareArea.Start();            
            rectangleArea.Start();
            circleArea.Start();
            squarePerimeter.Start();
            rectanglePerimeter.Start();
            circlePerimeter.Start();            
        }
    }
}
