public interface IVisitor
{
    void Visit(Book book);
    void Visit(Fruit fruit);
}

public interface IItem
{
    void Accept(IVisitor visitor);
}

public class Book : IItem
{
    public string Title { get; }
    public double Price { get; }

    public Book(string title, double price)
    {
        Title = title;
        Price = price;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Fruit : IItem
{
    public string Name { get; }
    public double Weight { get; }
    public double PerPackPrice { get; }

    public Fruit(string name, double weight, double price)
    {
        Name = name;
        Weight = weight;
        PerPackPrice = price;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class PriceCalculatedVisitor : IVisitor
{
    public double TotalPrice { get; private set; }

    public void Visit(Book book)
    {
        TotalPrice += book.Price;
    }

    public void Visit(Fruit fruit)
    {
        TotalPrice += fruit.Weight * fruit.PerPackPrice;
    }
}


class Program
{
    static void Main(string[] args)
    {
        IItem[] items = {
            new Book("C# in depth", 30.0),
            new Book("CLR via C#", 35.0),
            new Fruit("Apple", 1.2, 5.0)
        };

        var visitor = new PriceCalculatedVisitor();
        foreach (var item in items)
        {
            item.Accept(visitor);
        }

        System.Console.WriteLine($"Total price: {visitor.TotalPrice}");
    }
}