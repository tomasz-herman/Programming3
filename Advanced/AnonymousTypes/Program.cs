using System.Runtime.CompilerServices;

namespace AnonymousTypes;

class Program
{
    static void Main(string[] args)
    {
        AnonymousTypes();
        InferringNames();
        Equality();
        NonDestructiveMutation();
    }

    private static void AnonymousTypes()
    {
        PrintCurrentMethodName();
        var bob = new { Name = "Bob", Age = 23 };
        Console.WriteLine($"{bob.GetType()} is {bob.Name} and {bob.Age} years old.");
    }

    private static void InferringNames()
    {
        PrintCurrentMethodName();
        int age = 23;
        var bob = new { Name = "Bob", age, age.ToString().Length };
        Console.WriteLine($"His {nameof(bob.Name)} is {bob.Name}");
        Console.WriteLine($"His {nameof(bob.age)} is {bob.age}");
        Console.WriteLine($"His {nameof(bob.Length)} is {bob.Length}");
    }

    private static void Equality()
    {
        PrintCurrentMethodName();
        var a = new { X = 1, Y = 2, Z = 3 };
        var b = new { X = 1, Y = 2, Z = 3 };
        Console.WriteLine(a.Equals(b)); // True
        Console.WriteLine(a == b); // False
    }

    private static void NonDestructiveMutation()
    {
        PrintCurrentMethodName();
        var a = new { X = 1, Y = 2, Z = 3 };
        var b = a with { X = 10, Y = 20 };
        Console.WriteLine($"a = (X = {a.X}, Y = {a.Y}, Z = {a.Z})");
        Console.WriteLine($"b = (X = {b.X}, Y = {b.Y}, Z = {b.Z})");
    }
    
    private static void PrintCurrentMethodName([CallerMemberName] string caller = "")
    {
        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {caller,27} *");
        Console.WriteLine("***************************************");
    }
}