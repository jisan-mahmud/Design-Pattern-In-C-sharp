using System;

public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Render();
}

public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows Button");
    }
}

public class WindowsCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows Checkbox");
    }
}

public class MacButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Mac Button");
    }
}

public class MacCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Mac Checkbox");
    }
}

public interface IFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}


public class WindowsFactory : IFactory
{
    public IButton CreateButton() => new WindowsButton();

    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}


public class MacFactory : IFactory
{
    public IButton CreateButton() => new MacButton();

    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

class Program
{
    
    static void Main(string[] args)
    {   
        // Windows client
        IFactory windowsFactory = new WindowsFactory();
        IButton windowsButton = windowsFactory.CreateButton();
        windowsButton.Render();
        ICheckbox windowsCheckbox = windowsFactory.CreateCheckbox();
        windowsCheckbox.Render();


        // Mac client
        IFactory macFactory = new MacFactory();
        IButton macButton = macFactory.CreateButton();
        macButton.Render();
        ICheckbox macCheckbox = macFactory.CreateCheckbox();
        macCheckbox.Render();
    }
}