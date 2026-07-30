public interface IObserve
{
    void Update(string message);
}

public class Subsciber : IObserve
{
    public string name;
    public Subsciber(string name)
    {
        this.name = name;
    }
    public void Update(string message)
    {
        System.Console.WriteLine(message);
    }
}


public class YoutubeChannel
{
    private List<Subsciber> subscibers = new();
    private string channelName;

    public YoutubeChannel(string channelName)
    {
        this.channelName = channelName;
    }

    public void Subscribe(Subsciber subsciber)
    {
        subscibers.Add(subsciber);
    }

    public void UnSubscribe(Subsciber subsciber)
    {
        subscibers.Remove(subsciber);
    }

    public void UploadVideo(string title)
    {
        foreach (var subsciber in subscibers)
        {
            subsciber.Update($"{subsciber.name} : {channelName} has uploaded a video - {title}");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        YoutubeChannel ytc = new YoutubeChannel("C# with Sandeep");
        Subsciber s1 = new Subsciber("Ramesh");
        ytc.Subscribe(s1);
        Subsciber s2 = new Subsciber("Suresh");
        ytc.Subscribe(s2);

        ytc.UploadVideo("Observer Design Pattern in C#");

    }
}