using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ValueTypes;

public static class Program
{
    private static void Main()
    {
        NumericTypes();
        BoolType();
        CharType();
        ConvertClassAndParse();
    }

    private static void NumericTypes()
    {
        PrintCurrentMethodName();
        // Signed types:
        sbyte int8 = 100;
        short int16 = 10_000;
        int int32 = 1_000_000;
        long int64 = 100_000_000_000L;
        Int128 int128 = new Int128(0, 100_000_000_000_000UL);
        nint nint = 100_000_000;
        
        // Unsigned types:
        byte uint8 = 100;
        ushort uint16 = 10_000;
        uint uint32 = 1_000_000U;
        ulong uint64 = 100_000_000_000UL;
        UInt128 uint128 = new UInt128(0, 100_000_000_000_000UL);
        nuint nuint = 100_000_000U;
        
        // Real types:
        Half float16 = Half.One;
        float float32 = 1.0f;
        double float64 = 1.0;
        decimal decimal128 = 1.0m;
    }

    private static void BoolType()
    {
        PrintCurrentMethodName();
        bool isRaining = false;
        float temperature = 12.0f;

        if (!isRaining && (temperature > 20) && IsWeekend())
        {
            Console.WriteLine("It's a nice weather this weekend!");
        }

        if (!isRaining & (temperature > 20) & IsWeekend())
        {
            Console.WriteLine("It's a nice weather this weekend!");
        }
    }

    private static bool IsWeekend()
    {
        DayOfWeek today = DateTime.Now.DayOfWeek;

        if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
        {
            Console.WriteLine("It's weekend");
            return true;
        }

        Console.WriteLine("It is not a weekend yet");
        return false;
    }

    private static void CharType()
    {
        PrintCurrentMethodName();
        char a = 'a';
        char newLine = '\n';
        char quote = '\'';
        char unicode = '\u00A9';
        char hex = '\x005C';
        Console.WriteLine($"Size of char: {sizeof(char)} bytes");
    }

    private static void ConvertClassAndParse()
    {
        PrintCurrentMethodName();
        bool fromInteger = Convert.ToBoolean(42);
        int fromBool = Convert.ToInt32(fromInteger);
        Console.WriteLine(fromBool);

        int parsed = int.Parse("42");
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