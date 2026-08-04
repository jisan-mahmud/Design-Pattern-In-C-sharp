public interface IObserver
{
    void Update(string message);
}

public class Subsciber : IObserver
{
    private string name;

    public Subsciber(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        System.Console.WriteLine(message);
    }
}


public class YouTubeChannel
{
    private List<IObserver> observers = new List<IObserver>();

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void UploadVideo(string title)
    {
        foreach (var observer in observers)
        {
            observer.Update($"New video uploaded: {title}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        YouTubeChannel channel = new YouTubeChannel();

        Subsciber subscriber1 = new Subsciber("Subscriber 1");
        Subsciber subscriber2 = new Subsciber("Subscriber 2");

        channel.Subscribe(subscriber1);
        channel.Subscribe(subscriber2);

        channel.UploadVideo("Observer Design Pattern in C#");

        channel.Unsubscribe(subscriber1);

        channel.UploadVideo("Another Video");
    }
}