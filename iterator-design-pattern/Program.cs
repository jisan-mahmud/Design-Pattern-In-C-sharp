public interface IIterator
{
    bool HasNext();
    object Next();
}


public class StudentIterator : IIterator
{
    private List<Student> _students;
    private int _position = 0;

    public StudentIterator(List<Student> students)
    {
        this._students = students;
    }

    public bool HasNext()
    {
        return _position < _students.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            return _students[_position++];
        }
        else
        {
            throw new InvalidOperationException("No more elements");
        }
    }
}


public class StudentCollection
{
    private List<Student> _students = new List<Student>();

    public void Add(Student student)
    {
        _students.Add(student);
    }

    public IIterator CreateIterator()
    {
        return new StudentIterator(_students);
    } 
}


public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}


class Program
{
    static void Main(string[] args)
    {
        StudentCollection collection = new StudentCollection();
        collection.Add(new Student { Name = "Alice", Age = 20 });
        collection.Add(new Student { Name = "Bob", Age = 22 });
        collection.Add(new Student { Name = "Charlie", Age = 21 });

        IIterator iterator = collection.CreateIterator();

        while (iterator.HasNext())
        {
            Student student = (Student)iterator.Next();
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
        }
    }
}