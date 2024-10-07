using System;

namespace FirstProgram;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string name = "Alice";
        Console.WriteLine($"Hello, {name}!");                                                                                                                       

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Count: {i}");
        }
    }
}