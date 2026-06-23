using System;

public abstract class Approver
{
    protected Approver _nextApprover;

    public void SetNext(Approver approver)
    {
        _nextApprover = approver;
    }

    public abstract void ProcessRequest(decimal amount);
}

public class Manager : Approver
{
    public override void ProcessRequest(decimal amount)
    {
        if(amount < 5000)
        {
            Console.WriteLine($"Your request accept for amount {amount}.");
            Console.WriteLine("This request accepted by Mananger!");
        }
        else if(_nextApprover != null)
        {
            _nextApprover.ProcessRequest(amount);
        }
    }
}


public class Director : Approver
{
    public override void ProcessRequest(decimal amount)
    {
        if(amount < 50000)
        {
            Console.WriteLine($"Your request accept for amount {amount}.");
            Console.WriteLine("This request accepted by Director!");
        }
        else if(_nextApprover != null)
        {
            _nextApprover.ProcessRequest(amount);
        }
    }
}

public class CEO : Approver
{
    public override void ProcessRequest(decimal amount)
    {
        Console.WriteLine($"Your request accept for amount {amount}.");
        Console.WriteLine("Your request accepted by CEO!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Approver manager = new Manager();
        Approver director = new Director();
        Approver ceo = new CEO();

        manager.SetNext(director);
        director.SetNext(ceo);

        manager.ProcessRequest(200000);
    }
}