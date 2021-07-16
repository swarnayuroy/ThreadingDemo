using System;
using System.Threading;

namespace ThreadingDemo2
{
    class Square : IShape
    {
        private double _side;
        public Square(double side)
        {
            this._side = side;
        }
        public string CalculateArea()
        {
            double area = _side * _side;
            return $"Area of the square {Math.Round(area, 2)} cmsq";
        }

        public string CalculatePerimeter()
        {
            double perimeter = _side * 4;
            return $"Perimeter of the square {Math.Round(perimeter, 2)} cm";
        }
    }
    class Rectangle : IShape
    {
        private double _length;
        private double _width;
        public Rectangle(double length, double width)
        {
            this._length = length;
            this._width = width;
        }

        public string CalculateArea()
        {
            double area = _length * _width;
            return $"Area of the rectangle {Math.Round(area, 2)} cmsq";
        }

        public string CalculatePerimeter()
        {
            double perimeter = 2 * (_length + _width);
            return $"Perimeter of the rectangle {Math.Round(perimeter, 2)} cm";
        }
    }
    class Circle : IShape
    {
        private double _radius;
        public Circle(double radius)
        {
            this._radius = radius;
        }

        public string CalculateArea()
        {
            double area = 3.14 * _radius * _radius;
            return $"Area of the circle {Math.Round(area, 2)} cmsq";
        }

        public string CalculatePerimeter()
        {
            double circumference = 2 * 3.14 * _radius;
            return $"Circumference of the circle is {Math.Round(circumference, 2)} cm";
        }
    }
    class Program
    {
        private static IShape shape = null;
        private static string result = null;
        static void Main(string[] args)
        {
            //Working with the shape square
            shape = new Square(10.5);
            Thread squareArea = new Thread(new ThreadStart
                    (delegate{
                        result = shape.CalculateArea();
                    })
                );
            Thread squarePerimeter = new Thread(new ThreadStart
                    (delegate {
                        result = shape.CalculatePerimeter();
                    })
                );
            squareArea.Start();
            squareArea.Join();
            Console.WriteLine(result);
            squarePerimeter.Start();
            squarePerimeter.Join();
            Console.WriteLine(result);

            //Working with the shape rectangle
            shape = new Rectangle(20.4, 10.5);
            Thread rectArea = new Thread(new ThreadStart
                    (delegate {
                        result = shape.CalculateArea();
                    })
                );
            Thread rectPerimeter = new Thread(new ThreadStart
                    (delegate {
                        result = shape.CalculatePerimeter();
                    })
                );
            rectArea.Start();
            rectArea.Join();
            Console.WriteLine(result);
            rectPerimeter.Start();
            rectPerimeter.Join();
            Console.WriteLine(result);

            //Working with the shape circle
            shape = new Circle(10.8);
            Thread circleArea = new Thread(new ThreadStart
                    (delegate {
                        result = shape.CalculateArea();
                    })
                );
            Thread circlePerimeter = new Thread(new ThreadStart
                    (delegate {
                        result = shape.CalculatePerimeter();
                    })
                );
            circleArea.Start();
            circleArea.Join();
            Console.WriteLine(result);
            circlePerimeter.Start();
            circlePerimeter.Join();
            Console.WriteLine(result);
        }
    }
}
