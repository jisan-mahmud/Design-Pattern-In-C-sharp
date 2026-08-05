public interface IState
{
    void Handle();
}


public class RedState : IState
{
    public void Handle()
    {
        Console.WriteLine("Red Light -> Stop");
    }
}

public class YellowState : IState
{
    public void Handle()
    {
        Console.WriteLine("Yellow Light -> Wait");
    }
}


public class GreenState : IState
{
    public void Handle()
    {
        Console.WriteLine("Green Light -> Go");
    }
}


public class TrafficLight
{
    private IState _state;

    public void SetState(IState state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.Handle();
    }
}


class Program
{
    static void Main(string[] args)
    {
        TrafficLight trafficLight = new TrafficLight();

        trafficLight.SetState(new RedState());
        trafficLight.Request();

        trafficLight.SetState(new YellowState());
        trafficLight.Request();

        trafficLight.SetState(new GreenState());
        trafficLight.Request();
        
    }
}