public interface IChatMediator
{
    void SendMessage(string message, User sender);
}

public class ChatMediator : IChatMediator
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.ReceiveMessage(message);
            }
        }
    }
}


public class User
{
    private string _name;
    private IChatMediator _mediator;

    public User(string name, IChatMediator mediator)
    {
        _name = name;
        _mediator = mediator;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{_name} sends: {message}");
        _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{_name} receives: {message}");
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

        user1.SendMessage("Hello, everyone!");
        user2.SendMessage("Hi Alice!");
        user3.SendMessage("Hey Bob!");
    }
}