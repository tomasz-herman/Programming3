namespace Types;

class Program
{
    static void Main(string[] args)
    {
        // struct assignment semantics
        Point p1 = new Point(3, -5);
        Point p2 = p1;
        p2.X = 1; p2.Y = -1;
        Console.WriteLine($"P1: {p1.X}, {p1.Y}");
        Console.WriteLine($"P2: {p2.X}, {p2.Y}");

        // class assignment semantics
        Person alice = new Person("Alice", 16);
        Person bob = alice;
        bob.Name = "Bob"; bob.Age = 18;
        Console.WriteLine($"Alice: {alice.Name}, {alice.Age}");
        Console.WriteLine($"Bob: {bob.Name}, {bob.Age}");
        
        // struct - null value
        Point p = new Point();
        p.X = 3; p.Y = -5;
        // p = null; // Compilation error
            
        // class - null value
        Person daniel = new Person("Daniel", 17);
        daniel = null; // OK
    }
}

public struct Point
{
    public float X, Y;

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }
}

public class Person
{
    public string Name; 
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}