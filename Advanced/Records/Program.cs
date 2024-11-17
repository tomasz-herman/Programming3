using System.Runtime.CompilerServices;

namespace Records;

public record Person(string FirstName, string LastName);
public readonly record struct Point(double X, double Y);
public record struct Vector3(double X, double Y, double Z);

public record Product(string Name, decimal Price)
{
    public int Quantity { get; set; }

    public Product(Product original)
    {
        Name = original.Name;
        Price = original.Price;
        Quantity = 0;
    }

    public override string ToString() => $"{Name}({Quantity}): {Price:C}";
}

class Program
{
    static void Main()
    {
        RecordsIntroduction();
        EqualitySemantics();
        NonDestructiveMutation();
        CustomizingRecords();
    }

    private static void RecordsIntroduction()
    {
        PrintCurrentMethodName();
        var person = new Person("John", "Doe");
        Point point = new Point(10, 10);
        Vector3 vector = new Vector3(1, 0, 1);
        Console.WriteLine($"Person: {person}");
        Console.WriteLine($"Point: {point}");
        Console.WriteLine($"Vector3: {vector}");
    }
    
    private static void EqualitySemantics()
    {
        PrintCurrentMethodName();
        var john = new Person("John", "Doe");
        var doe = new Person("John", "Doe");
        Point p1 = new (10, 10), p2 = new (10, 10);
        Vector3 v1 = new (1, 0, 1), v2 = new (1, 0, 1);
        Console.WriteLine($"Person: {john == doe}");
        Console.WriteLine($"Point: {p1 == p2}");
        Console.WriteLine($"Vector3: {v1 == v2}");
    }

    private static void NonDestructiveMutation()
    {
        PrintCurrentMethodName();
        Point p1 = new Point (1, 1);
        Point p2 = p1 with { Y = 2 };
        Console.WriteLine(p1);
        Console.WriteLine(p2);
    }
    
    private static void CustomizingRecords()
    {
        PrintCurrentMethodName();
        Product product = new Product("Apple", 1.99m) { Quantity = 5 };
        Product copy = product with {Price = 2.99m};

        Console.WriteLine(product);
        Console.WriteLine(copy);
    }
        
    private static void PrintCurrentMethodName([CallerMemberName] string caller = "")
    {
        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {caller,27} *");
        Console.WriteLine("***************************************");
    }
}