using System;
using System.Collections.Generic;

// Definicja klasy bazowej Shape
public abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    // Wirtualna metoda Draw
    public abstract void Draw();
}

// Klasa Rectangle dziedzicząca po Shape
public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysujemy prostokąt.");
    }
}

// Klasa Triangle dziedzicząca po Shape
public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysujemy trójkąt.");
    }
}

// Klasa Circle dziedzicząca po Shape
public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysujemy koło.");
    }
}

// Program główny
class Program
{
    static void Main(string[] args)
    {
        // Tworzymy listę typu Shape
        List<Shape> shapes = new List<Shape>();

        // Dodajemy obiekty różnych klas
        shapes.Add(new Rectangle { X = 0, Y = 0, Height = 10, Width = 20 });
        shapes.Add(new Triangle { X = 1, Y = 1, Height = 15, Width = 15 });
        shapes.Add(new Circle { X = 2, Y = 2, Height = 10, Width = 10 });

        // Wywołujemy metodę Draw dla każdego elementu w liście
        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}
