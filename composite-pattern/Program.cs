using System;

public abstract class OrganizationUnit
{
    private string _name;

    public OrganizationUnit(string name)
    {
        this._name = name;
    }

    public abstract int GetBudget();

    public virtual void AddUnit(OrganizationUnit unit)
    {
        Console.WriteLine("This a leaf node. Cannot add a unit.");
    }

    public virtual void RemoveUnit(OrganizationUnit unit)
    {
        Console.WriteLine("This a leaf node. Cannot remove a unit.");
    }

}


public class Employee : OrganizationUnit
{
    private int _salary;

    public Employee(string name, int salary) : base(name)
    {
        this._salary = salary;
    }

    public override int GetBudget()
    {
        return _salary;
    }
}

public class Department : OrganizationUnit
{
    private List<OrganizationUnit> _units = new List<OrganizationUnit>();

    public Department(string name) : base(name)
    {
    }

    public override int GetBudget()
    {
        int totalBudget = 0;
        foreach (var unit in _units)
        {
            totalBudget += unit.GetBudget();
        }
        return totalBudget;
    }

    public override void AddUnit(OrganizationUnit unit)
    {
        _units.Add(unit);
    }

    public override void RemoveUnit(OrganizationUnit unit)
    {
        _units.Remove(unit);
    }
}


public class Company : OrganizationUnit
{
    private List<OrganizationUnit> _departments = new List<OrganizationUnit>();

    public Company(string name) : base(name)
    {
    }

    public override int GetBudget()
    {
        int totalBudget = 0;
        foreach (var department in _departments)
        {
            totalBudget += department.GetBudget();
        }
        return totalBudget;
    }

    public override void AddUnit(OrganizationUnit unit)
    {
        _departments.Add(unit);
    }

    public override void RemoveUnit(OrganizationUnit unit)
    {
        _departments.Remove(unit);
    }
}



public class Program
{
    static void Main(string[] args)
    {
        Company company = new Company("TechCorp");

        Department development = new Department("Development");
        var employee1 = new Employee("Alice", 70000);
        var employee2 = new Employee("Bob", 80000);
        development.AddUnit(employee1);
        development.AddUnit(employee2);

        Department marketing = new Department("Marketing");
        var employee3 = new Employee("Charlie", 60000);
        var employee4 = new Employee("Diana", 65000);
        marketing.AddUnit(employee3);
        marketing.AddUnit(employee4);

        company.AddUnit(development);
        company.AddUnit(marketing);

        development.RemoveUnit(employee1);

        Console.WriteLine($"Total budget for {company.GetBudget()}");
    }
}