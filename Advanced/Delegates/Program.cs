using System.Diagnostics;

namespace Delegates;

class Program
{
    // Delegate type declaration:
    public delegate double Function(double x);
    
    static void Main(string[] args)
    {
        DelegatesIntroduction();
        GenericDelegates();
        BuiltinDelegates();
        MulticastDelegates();
    }

    private static void DelegatesIntroduction()
    {
        PrintCurrentMethodName();
        Function func = Square;
        // Equivalent:
        // Function func = new Function(Square);
        double result = func(3);
        // Equivalent:
        // double result = func.Invoke(3);
        Console.WriteLine(result);
    }
    
    public static double Square(double x) => x * x;

    public delegate T GenericFunction<T>(T x);

    private static void GenericDelegates()
    {
        PrintCurrentMethodName();
        GenericFunction<double> func = Square;
        double result = func(3);
        Console.WriteLine(result);
    }

    private static void BuiltinDelegates()
    {
        PrintCurrentMethodName();
        Func<double, double> func = Square;
        double result = func(3);
        Action<double> write = Console.WriteLine;
        write(result);
    }
    
    private static void MulticastDelegates()
    {
        PrintCurrentMethodName();
        Action<string> writeLog = null!;
        writeLog += Console.WriteLine;
        writeLog += WriteLogToFile;
        writeLog("DEBUG: This is a test log");
    }

    private static void WriteLogToFile(string log)
    {
        File.WriteAllText("test.log", log);
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