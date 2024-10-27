using System.Diagnostics;

namespace Enumeration;

public class Program
{
    private static void Main(string[] args)
    {
        Enumerable();
        IteratorMethods();
    }

    private static void Enumerable()
    {
        PrintCurrentMethodName();
        Stack<string> stack = new Stack<string>();
        stack.Push("The");
        stack.Push("quick");
        stack.Push("brown");
        stack.Push("fox");
        stack.Push("jumps");
        stack.Push("over");
        stack.Push("the");
        stack.Push("lazy");
        stack.Push("dog");
        Console.WriteLine("Stack implements IEnumerable it can be used in a foreach");
        foreach (var str in stack)
        {
            Console.WriteLine(str);
        }
    }

    private static void IteratorMethods()
    {
        PrintCurrentMethodName();
        Console.WriteLine("Fibonacci sequence:");
        foreach (var item in Fibonacci(10))
        {
            Console.WriteLine(item);
        }

        var sequence = Odds(Fibonacci(10));
        Console.WriteLine("Odd elements of the fibonacci sequence:");
        foreach (var item in sequence)
        {
            Console.WriteLine(item);
        }
    }
    
    private static IEnumerable<int> Fibonacci(int n)
    {
        int current = 0, next = 1;
        for (int i = 0; i < n; i++)
        {
            yield return current;
            (current, next) = (next, current + next);
        }
    }
    
    private static IEnumerable<int> Odds(IEnumerable<int> sequence)
    {
        foreach (var item in sequence)
        {
            if (item % 2 == 1) yield return item;
        }
    }
    
    private static void PrintCurrentMethodName()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);

        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {sf!.GetMethod()!.Name,27} *");
        Console.WriteLine("***************************************");
    }
}