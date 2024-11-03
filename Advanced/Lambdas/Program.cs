using System.Diagnostics;

namespace Lambdas;

class Program
{
    static void Main(string[] args)
    {
        LambdasDeclaration();
        ExplicitParameterAndReturn();
        DefaultParameters();
        CapturingVariables();
    }

    private static void LambdasDeclaration()
    {
        PrintCurrentMethodName();
        // Can skip parenthesis if lambda takes only 1 parameter:
        Func<double, double> square = x => x * x;
        Func<string> greet = () => "Hello, world";
        Func<char, int, string> repeat = (c, i) => new string(c, i);
        Action<string> write = str => Console.Write(str);
    }
    
    private static void ExplicitParameterAndReturn()
    {
        PrintCurrentMethodName();
        Func<double, double> square = double (double x) => x * x;
        Func<string> greet = string () => "Hello, world";
        Func<char, int, string> repeat = string (char c, int i) => new string(c, i);
        Action<string> write = void (string str) => Console.Write(str);
    }
    
    private static void DefaultParameters()
    {
        PrintCurrentMethodName();
        var write = (string str = "hello") => Console.Write(str);
        write();
        write("world");
        Console.WriteLine();
    }

    private static void CapturingVariables()
    {
        PrintCurrentMethodName();
        Action[] actions = new Action[3];
        for (int i = 0; i < 3; i++)
            actions [i] = () => Console.Write(i);
        foreach (Action action in actions) action();
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