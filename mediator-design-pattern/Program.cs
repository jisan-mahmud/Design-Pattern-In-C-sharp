public interface IChatMediator
{
    void SendMessage(string message, User user);
}


public class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in users)
        {
            if (u != user)
            {
                u.Receive(message);
            }
        }
    }
}

public class User
{
    private string name;
    private ChatMediator mediator;

    public User(string name, ChatMediator mediator)
    {
        this.name = name;
        this.mediator = mediator;
    }

    public void Send(string message)
    {
        System.Console.WriteLine($"{name} sends: {message}");
        mediator.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        System.Console.WriteLine($"{name} receives: {message}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        ChatMediator mediator = new ChatMediator();

        User user1 = new User("Alice", mediator);
        User user2 = new User("Bob", mediator);
        User user3 = new User("Charlie", mediator);

        mediator.AddUser(user1);
        mediator.AddUser(user2);
        mediator.AddUser(user3);

        user1.Send("Hello, everyone!");
        user2.Send("Hi Alice!");
        user3.Send("Hey there!");
    }
}