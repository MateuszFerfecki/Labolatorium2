using System;

abstract class Shape
{
    public abstract double CalculateArea();
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

class Square : Shape
{
    private double sideLength;

    public Square(double sideLength)
    {
        this.sideLength = sideLength;
    }

    public override double CalculateArea()
    {
        return sideLength * sideLength;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Shape circle = new Circle(2);//podajemy wartośc 
        Console.WriteLine("Pole koła: " + circle.CalculateArea());

     
        Shape square = new Square(5); //podajemy wartośc 
        Console.WriteLine("Pole kwadratu: " + square.CalculateArea());
    }
}
