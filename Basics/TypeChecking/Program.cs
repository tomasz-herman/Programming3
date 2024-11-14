using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TypeChecking;

public class Base { }
public class Derived : Base 
{ 
    int Foo() => 42;
}

public class Animal { }
public class Giraffe : Animal { }

public static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    private static void TypePattern()
    {
        PrintCurrentMethodName();
        object b = new Base();
        Console.WriteLine(b is Base);  // output: True
        Console.WriteLine(b is Derived);  // output: False

        object d = new Derived();
        Console.WriteLine(d is Base);  // output: True
        Console.WriteLine(d is Derived); // output: True
    }
    
    private static void DeclarationPattern()
    {
        PrintCurrentMethodName();
        object b = new Base();
        Console.WriteLine(b is Base);  // output: True
        Console.WriteLine(b is Derived);  // output: False

        object d = new Derived();
        Console.WriteLine(d is Base);  // output: True
        Console.WriteLine(d is Derived); // output: True
    }

    private static void AsOperator()
    {
        PrintCurrentMethodName();
        IEnumerable<int> numbers = new List<int>(){10, 20, 30};
        IList<int>? list = numbers as IList<int>;
        if (list != null)
        {
            Console.WriteLine(list[0] + list[^1]);  
        }   // output: 40
    }
    
    private static void CastExpression()
    {
        PrintCurrentMethodName();
        double x = 1234.7;
        int a = (int)x;
        Console.WriteLine(a);   // output: 1234

        List<int> ints = [10, 20, 30];
        IEnumerable<int> numbers = ints;
        IList<int> list = (IList<int>)numbers;
        Console.WriteLine(list.Count);  // output: 3
        Console.WriteLine(list[1]);  // output: 20
    }
    
    private static void TypeOfExpression()
    {
        PrintCurrentMethodName();
        object b = new Giraffe();
        Console.WriteLine(b is Animal);  // True
        Console.WriteLine(b.GetType() == typeof(Animal));  // False

        Console.WriteLine(b is Giraffe);  // True
        Console.WriteLine(b.GetType() == typeof(Giraffe));  // True
    }
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void PrintCurrentMethodName()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);

        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {sf!.GetMethod()!.Name,27} *");
        Console.WriteLine("***************************************");
    }
}