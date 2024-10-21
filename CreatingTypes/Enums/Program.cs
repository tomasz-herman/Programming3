using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Enums;

class Program
{
    static void Main(string[] args)
    {
        UsingEnums();
        FlagsEnums();
    }

    private static void UsingEnums()
    {
        PrintCurrentMethodName();
        
        var side = BorderSide.Top;
        if (side == BorderSide.Top)
        {
            Console.WriteLine("Top border side");
        }
    }
    
    private static void FlagsEnums()
    {
        PrintCurrentMethodName();
        
        var allButTop = Anchor.All ^ Anchor.Top;
        Console.WriteLine($"Includes left: {(allButTop & Anchor.Left) == Anchor.Left}");
        Console.WriteLine($"Includes right: {(allButTop & Anchor.Right) == Anchor.Right}");
        Console.WriteLine($"Includes top: {(allButTop & Anchor.Top) == Anchor.Top}");
        Console.WriteLine($"Includes bottom: {(allButTop & Anchor.Bottom) == Anchor.Bottom}");
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