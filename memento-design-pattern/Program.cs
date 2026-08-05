class Memento
{
    public string State { get; set; }

    public Memento(string state)
    {
        State = state;
    }
}

class Document
{
    public string Text { get; set; }

    public Memento Save()
    {
        return new Memento(Text);
    }

    public void Restore(Memento memento)
    {
        Text = memento.State;
    }
}

class History
{
    private Stack<Memento> _history = new();

    public void Save(Memento memento)
    {
        _history.Push(memento);
    }

    public Memento Undo()
    {
        if (_history.Count <= 1)
            return null;

        _history.Pop();

        return _history.Peek();
    }
}


class Program
{
    static void Main(string[] args)
    {
        Document doc = new Document();
        History history = new History();
        doc.Text = "Hello";
        history.Save(doc.Save());

        doc.Text = "Hello world";
        history.Save(doc.Save());

        doc.Text = "Hello World!!!";
        history.Save(doc.Save());

        Console.WriteLine("Current Text" + doc.Text);

        // Undo
        Memento previous = history.Undo();

        while (previous != null)
        {
            doc.Restore(previous);
            Console.WriteLine($"After undo top element = {doc.Text}");
            previous = history.Undo();
        }
    }
}