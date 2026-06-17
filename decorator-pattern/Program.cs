public interface ICoffee
{
    string GetDescription();
    double GetCost();
}


public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 100.0;
    }
}


public class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return _coffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return _coffee.GetCost();
    }
}


class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Milk";
    }

    public override double GetCost()
    {
        return base.GetCost() + 20.0;
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Sugar";
    }

    public override double GetCost()
    {
        return base.GetCost() + 10.0;
    }
}


class Program
{
    static void Main(string[] args)
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} - Cost: {coffee.GetCost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - Cost: {coffee.GetCost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - Cost: {coffee.GetCost()}");

        ICoffee anotherCoffee = new SimpleCoffee();
        anotherCoffee = new SugarDecorator(anotherCoffee);
        Console.WriteLine($"{anotherCoffee.GetDescription()} - Cost: {anotherCoffee.GetCost()}");
    }
}