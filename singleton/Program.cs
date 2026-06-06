using System;

public class DBConnection
{
    private static DBConnection? _instance = null;

    private DBConnection() { }

    public static DBConnection GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DBConnection();
        }
        return _instance;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DBConnection db1 = DBConnection.GetInstance();
        DBConnection db2 = DBConnection.GetInstance();

        if (object.ReferenceEquals(db1, db2))
        {
            Console.WriteLine("Both instances are the same.");
        }
        else
        {
            Console.WriteLine("Instances are different.");
        }
    }
}