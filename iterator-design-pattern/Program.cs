public interface IIterator
{
    bool HasNext();
    object Next();
}

public class StudentIteratot : IIterator
{
    private List<Student> _students;
    private int _position;

    public StudentIteratot(List<Student> students)
    {
        _students = students;
        _position = 0;
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
        return null;
    }
}

public class StudentCollection
{
    private List<Student> _students;

    public StudentCollection()
    {
        _students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public IIterator GetIterator()
    {
        return new StudentIteratot(_students);
    }
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main(string[] args)
    {
        StudentCollection studentCollection = new StudentCollection();
        studentCollection.AddStudent(new Student("Alice", 20));
        studentCollection.AddStudent(new Student("Bob", 22));
        studentCollection.AddStudent(new Student("Charlie", 21));

        IIterator iterator = studentCollection.GetIterator();
        while (iterator.HasNext())
        {
            Student student = (Student)iterator.Next();
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
        }
    }
}