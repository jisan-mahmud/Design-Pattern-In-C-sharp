public class Computer
{
    public string? CPU { get; set; }
    public string? RAM { get; set; }
    public string? Storage { get; set; }
    public string? GraphicsCard { get; set; }

    public void DisplayConfiguration()
    {
        Console.WriteLine($"CPU: {CPU}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"Storage: {Storage}");
        Console.WriteLine($"Graphics Card: {GraphicsCard}");
    }
}

public interface IComputerBuilder
{
    void SetCPU();
    void SetRAM();
    void SetStorage();
    void SetGraphicsCard();
    Computer GetComputer();
}

public class GamingComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();

    public void SetCPU()
    {
        _computer.CPU = "Intel Core i9";
    }

    public void SetRAM()
    {
        _computer.RAM = "32GB";
    }

    public void SetStorage()
    {
        _computer.Storage = "1TB SSD";
    }

    public void SetGraphicsCard()
    {
        _computer.GraphicsCard = "NVIDIA GeForce RTX 3080";
    }

    public Computer GetComputer()
    {
        return _computer;
    }
}

class ComputerDirector
{
    private IComputerBuilder _builder;

    public ComputerDirector(IComputerBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructComputer()
    {
        _builder.SetCPU();
        _builder.SetRAM();
        _builder.SetStorage();
        _builder.SetGraphicsCard();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IComputerBuilder builder = new GamingComputerBuilder();
        ComputerDirector director = new ComputerDirector(builder);
        director.ConstructComputer();
        Computer gamingComputer = builder.GetComputer();
        Console.WriteLine("Gaming Computer:");
        gamingComputer.DisplayConfiguration();
    }
}