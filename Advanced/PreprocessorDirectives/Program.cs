#define TEST
#undef TRACE

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PreprocessorDirectives;

class Program
{
    static void Main(string[] args)
    {
        ConditionalCompilation();
        ConditionalAttribute();
        NullableContext();
        Region();
        PragmaWarning();
        ErrorAndWarning();
    }

    private static void ConditionalCompilation()
    {
        PrintCurrentMethodName();
        #if TEST
            Console.WriteLine("TEST is defined");
        #endif
        #if !TEST
            Console.WriteLine("TEST is not defined");
        #endif
        #if TEST && DEBUG
            Console.WriteLine("DEBUG and TEST is defined");
        #else
            Console.WriteLine("DEBUG or TEST is not defined");
        #endif
    }

    private static void ConditionalAttribute()
    {
        PrintCurrentMethodName();
        Log.Trace("This line will be visible only when TRACE or DEBUG is defined.");
        Log.Debug("This line will be visible only when DEBUG is defined.");
        Log.Info("This line will be always visible.");
    }
    
    private static void NullableContext()
    {
        PrintCurrentMethodName();
#nullable disable
        string str1 = null;
#nullable enable
        string str2 = null!;
#nullable restore
        string str3 = null!;
    }

    #region REGION_EXPLANATION
    private static void Region()
        {
            PrintCurrentMethodName();
            Console.WriteLine("#region is a preprocessor directive " +
                              "that is used to group related pieces of code together " +
                              "in a way that can be collapsed or expanded in the code editor.");
        }
    #endregion

    private static void PragmaWarning()
    {
        PrintCurrentMethodName();
#pragma warning disable CS0219
        string str = "Hello, world!";
#pragma warning restore CS0219
    }

    private static void ErrorAndWarning()
    {
        PrintCurrentMethodName();
#if !DEMO
    #error DEMO is not defined
        Console.WriteLine("This code will not "+
            "compile if demo is not defined.");
#else
    #warning DEMO is not defined
        Console.WriteLine("This code will generate " +
            "a warning message if demo is defined.");
#endif
    }

    private static void PrintCurrentMethodName([CallerMemberName] string caller = "")
    {
        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {caller,27} *");
        Console.WriteLine("***************************************");
    }
}

public static class Log
{
    [Conditional("TRACE"), Conditional("DEBUG")]
    public static void Trace(string message)
    {
        Console.WriteLine(message);
    }

    [Conditional("DEBUG")]
    public static void Debug(string message)
    {
        Console.WriteLine(message);
    }
    
    public static void Info(string message)
    {
        Console.WriteLine(message);
    }
}