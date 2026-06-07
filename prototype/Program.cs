using System;

public abstract class Shape
{
    public string? color { get; set; }
    public abstract Shape Clone();
}

public class Circle : Shape
{
    public double radius { get; set; }
    public override Shape Clone()
    {
        return (Shape)MemberwiseClone();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        
        Circle circle1 = new Circle()
        {
            color = "Red",
            radius = 5
        };

        Circle circle2 = (Circle)circle1.Clone();
        circle2.radius = 10;

        Console.WriteLine("Circle 1: Color={0}, Radius={1}", circle1.color, circle1.radius);

        Console.WriteLine("Circle 2: Color={0}, Radius={1}", circle2.color, circle2.radius);


    }
}