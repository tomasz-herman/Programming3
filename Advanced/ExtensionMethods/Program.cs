namespace ExtensionMethods;

class Program
{
    static void Main(string[] args)
    {
        string greeting = "Hello Extension Methods";
        int i = MyExtensions.WordCount(greeting);   // May call it normally
        int j = greeting.WordCount();               // Or directly on the type
        Console.WriteLine($"Word count is {i} == {j}");

        foreach (var c in greeting.Filter(char.IsUpper))
        {
            Console.Write(c);
        }

        Console.WriteLine();
        foreach (var n in 10)
        {
            Console.Write(n);
        }
    }
}