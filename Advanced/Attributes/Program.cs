using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyDescription("Attributes demonstration")]

namespace Attributes;

public static class Program
{
    [field: NonSerialized] 
    private static bool Property { get; } = false;

    private static void Main()
    {
        AttributesIntroduction();
        AttributesTargets();
        MultipleAttributes();
        CallerInfoAttributes();
    }

    [Description("""
                 Attributes add metadata to your program.
                 Metadata is information about the types defined in a program.
                 You can apply one or more attributes to entire assemblies, modules, 
                    or smaller program elements such as classes and properties.
                 Attributes can accept arguments in the same way as methods and properties.
                 Your program can examine its own metadata or the 
                    metadata in other programs by using reflection.
                 """)]
    [Conditional("DEBUG")]
    [Obsolete]
    public static void AttributesIntroduction()
    {
        PrintCurrentMethodName();

        var attributes = MethodBase.GetCurrentMethod()?.GetCustomAttributes().ToList();
        if (attributes is null) return;
        foreach (var attribute in attributes)
        {
            Console.WriteLine(attribute.GetType());
            if (attribute is DescriptionAttribute description)
            {
                Console.WriteLine(description.Description);
            }
        }
    }

    public static void AttributesTargets()
    {
        PrintCurrentMethodName();
        
        var m1 = typeof(Program).GetMethod(nameof(Method1), BindingFlags.NonPublic | BindingFlags.Static);
        var d1 = m1?.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
        Console.WriteLine(d1?.Description);
        
        var m2 = typeof(Program).GetMethod(nameof(Method2), BindingFlags.NonPublic | BindingFlags.Static);
        var d2 = m2?.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
        Console.WriteLine(d2?.Description);
        
        var m3 = typeof(Program).GetMethod(nameof(Method3), BindingFlags.NonPublic | BindingFlags.Static);
        var p3 = m3?.GetParameters()[0];
        var d3 = p3?.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
        Console.WriteLine(d3?.Description);
        
        var m4 = typeof(Program).GetMethod(nameof(Method4), BindingFlags.NonPublic | BindingFlags.Static);
        var p4 = m4?.ReturnParameter;
        var d4 = p4?.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
        Console.WriteLine(d4?.Description);
    }
    
    [Description("By default it applies to a method")]
    private static int Method1() { return 0; }

    [method: Description("Explicitely applied to a method")]
    private static int Method2() { return 0; }

    private static int Method3([Description("Applied to a parameter")] string parameter) { return 0; }

    [return: Description("Applied to a return value")]
    private static int Method4() { return 0; }
    
    public static void MultipleAttributes()
    {
        PrintCurrentMethodName();
        
        var m = typeof(Program).GetMethod(nameof(Method5), BindingFlags.NonPublic | BindingFlags.Static);
        var attributes = m?.GetCustomAttributes();
        if (attributes is null) return;
        foreach (var attribute in attributes)
        {
            Console.WriteLine(attribute.GetType());
        }
    }
    
    [Description("Multiple attributes applied to a method"), Conditional("DEBUG")]
    private static void Method5() { Console.WriteLine("Hello World!"); }

    public static void CallerInfoAttributes()
    {
        PrintCurrentMethodName();
        Logger.Log("Hello, World!");
        Assertion.Assert("Hello, World!" is { Length: < 5 });
    }
    
    private static void PrintCurrentMethodName([CallerMemberName] string caller = "")
    {
        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {caller,27} *");
        Console.WriteLine("***************************************");
    }
}