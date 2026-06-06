using System;

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email notification sent: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS notification sent: {message}");
    }
}

public class NotificationFactory
{
    public static INotification CreateNotification(string type)
    {
        if (type == "Email")
        {
            return new EmailNotification();
        }
        else if (type == "SMS")
        {
            return new SMSNotification();
        }
        else
        {
            throw new ArgumentException("Invalid notification type");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        INotification emailNotification = NotificationFactory.CreateNotification("Email");
        emailNotification.Send("Hello via Email!");

        INotification smsNotification = NotificationFactory.CreateNotification("SMS");
        smsNotification.Send("Hello via SMS!");
    }
}