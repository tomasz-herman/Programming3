using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Structs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    private static void StructConstruction()
    {
        PrintCurrentMethodName();

        Vector2 p1 = new Vector2();
        Vector2 p2 = default;
        Console.WriteLine($"{p1.X}, {p1.Y}"); // 1, -1
        Console.WriteLine($"{p2.X}, {p2.Y}"); // 0, 0
    }
    
    private static void RefStructs()
    {
        PrintCurrentMethodName();

        Vector4 pos = new Vector4();
        Console.WriteLine($"{pos.X}, {pos.Y}, {pos.Z}, {pos.W}");
        // Vector4[] positions = new Vector4[10]; // Compile time error
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