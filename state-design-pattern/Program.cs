public interface IState
{
    void Handle(TrafficLight trafficLight);
}


public class RedState : IState
{
    public void Handle(TrafficLight trafficLight)
    {
        Console.WriteLine("Red Light -> Stop");


        trafficLight.SetState(new YellowState());
    }
}


public class YellowState : IState
{
    public void Handle(TrafficLight trafficLight)
    {
        Console.WriteLine("Yellow Light -> Wait");

        trafficLight.SetState(new GreenState());
    }
}

public class GreenState : IState
{
    public void Handle(TrafficLight trafficLight)
    {
        Console.WriteLine("Green Light -> Go");

        trafficLight.SetState(new RedState());
    }
}


public class TrafficLight
{
    private IState _state;
    public TrafficLight()
    {
        _state = new RedState();
    }

    public void SetState(IState state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.Handle(this);
    }
}

// Client
class Program
{
    static void Main(string[] args)
    {
        TrafficLight trafficLight = new TrafficLight();

        for (int i = 0; i < 3; i++)
        {
            trafficLight.Request();
        }
    }
}