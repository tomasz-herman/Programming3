using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Interfaces;

class Program
{
    static void Main(string[] args)
    {
        InterfacesBasics();
        ExplicitImplementation();
        InterfacesBoxing();
        InterfacesDefaultMembers();
        InterfacesStaticMembers();
    }

    public static void InterfacesBasics()
    {
        PrintCurrentMethodName();
        IEnumerator e = new Counter(10);
        while (e.MoveNext())
            Console.Write(e.Current);
        Console.WriteLine();
    }

    public static void ExplicitImplementation()
    {
        PrintCurrentMethodName();
        Foo foo = new Foo();
        ((IFoo1)foo).Bar();
        ((IFoo2)foo).Bar();
    }

    private static void InterfacesBoxing()
    {
        PrintCurrentMethodName();
        FooStruct s = new FooStruct();
        s.Bar(); // no boxing

        IFoo1 foo1 = s; // boxing
        foo1.Bar();
    }

    private static void InterfacesDefaultMembers()
    {
        PrintCurrentMethodName();
        Logger logger = new Logger();
        logger.Message("Hello, world");
    }

    private static void InterfacesStaticMembers()
    {
        PrintCurrentMethodName();
        Console.WriteLine($"Logger default file: {ILogger.DefaultFile}");

        Console.WriteLine($"Cat ({Cat.Category}): {Cat.Description}");
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

public interface IFoo1 { void Bar(); }
public interface IFoo2 { void Bar(); }

public class Foo : IFoo1, IFoo2
{ 
    public void Bar()
    {
        Console.WriteLine("Implementation of IFoo1.Bar");
    }

    void IFoo2.Bar()
    {
        Console.WriteLine("Implementation of IFoo2.Bar");
    }
}

public struct FooStruct : IFoo1
{
    public void Bar()
    {
        Console.WriteLine("Implementation of IFoo1.Bar");
    }
}