using System;
using System.Collections.Generic;

namespace Learning05
{
    public abstract class Shape
    {
        private string _color;
        public Shape(string color)
        {
            _color = color;
        }

        public string GetColor() => _color;
        public void SetColor(string color) => _color = color;
        public abstract double GetArea();
    }
    public class Square : Shape
    {
        private double _side;
        public Square(string color, double side) : base(color)
        {
            _side = side;
        }
        public override double GetArea() => _side * _side;
    }
    public class Rectangle : Shape
    {
        private double _length;
        private double _width;

        public Rectangle(string color, double length, double width) : base(color)
        {
            _length = length;
            _width = width;
        }
        public override double GetArea() => _length * _width;
    }
    public class Circle : Shape
    {
        private double _radius;
        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;
        }
        public override double GetArea() => Math.PI * Math.Pow(_radius, 2);
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Square("Red", 5));
            shapes.Add(new Rectangle("Blue", 10, 2));
            shapes.Add(new Circle("Green", 3));
            Console.WriteLine("Shape Area Report:");
            Console.WriteLine("------------------");
            foreach (Shape s in shapes)
            {
                string color = s.GetColor();
                double area = s.GetArea();

                Console.WriteLine($"The {color} shape has an area of {area:F2}.");
            }
        }
    }
}