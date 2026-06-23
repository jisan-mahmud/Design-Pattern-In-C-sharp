using System;

public interface ICommand
{
    void Execute();
}


public class Light
{
    public void On()
    {
        Console.WriteLine("Light is ON!");
    }

    public void Off()
    {
        Console.WriteLine("Light is OFF!");
    }
}


public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }
}


public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }
}


public class RemoteControll
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }


    public void PressButton()
    {
        _command.Execute();
    }

}

class Program
{
    static void Main(string[] args)
    {
        Light l1 = new Light();
        ICommand LightOn = new LightOnCommand(l1);
        ICommand LightOff = new LightOffCommand(l1);

        RemoteControll remote = new RemoteControll();
        remote.SetCommand(LightOn);

        remote.PressButton();

        remote.SetCommand(LightOff);
        remote.PressButton();
    }
}