using System;

public class Tree
{
    private string type;

    public Tree(string type)
    {
        this.type = type;
    }

    public void Display(int x, int y)
    {
        Console.WriteLine($"Displaying a {type} tree at ({x}, {y})");
    }
}


public class TreeFactory
{
    private Dictionary<string, Tree> trees = new Dictionary<string, Tree>();

    public Tree GetTree(string type)
    {
        if (!trees.ContainsKey(type))
        {
            trees[type] = new Tree(type);
        }
        return trees[type];
    }
}



class Program
{
    static void Main(string[] args)
    {
        TreeFactory factory = new TreeFactory();
        Tree tree1 = factory.GetTree("Oak");
        Tree tree2 = factory.GetTree("Pine");
        Tree tree3 = factory.GetTree("Oak");

        tree1.Display(10, 20);
        tree1.Display(10, 20);
        tree2.Display(30, 40);
        tree3.Display(50, 60);
    }
}