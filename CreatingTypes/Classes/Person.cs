namespace Classes;

public class Person
{
    // Constant
    public const int LegalAge = 18;

    // Static fields
    private static int _personCount;
    
    // Instance fields
    private string _firstName;
    private string _lastName;
    
    // Properties
    public int Age { get; private set; }
    public int Id { get; }
    public HashSet<Person> Friends { get; } = new HashSet<Person>();

    // Read-only property
    public string FullName => $"{_firstName} {_lastName}";

    // Constructor
    public Person(string firstName, string lastName, int age = 0)
    {
        _firstName = firstName;
        _lastName = lastName;
        Age = age;
        Id = _personCount++;
        Friends.Add(this);
    }

    public void Introduce() => Console.WriteLine($"Hello, my name is {FullName} and I am {Age} years old.");

    public bool IsLegalAge() => Age >= LegalAge;

    public void Deconstruct(out string fullName, out int age)
    {
        fullName = FullName;
        age = Age;
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Person other)
        {
            return Id == other.Id;
        }
        return false;
    }

    public override string ToString() => $"{FullName}, Age: {Age}";
}