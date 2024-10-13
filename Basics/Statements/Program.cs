using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Statements;

class Program
{
    static void Main(string[] args)
    {
        SwitchStatement();
        SwitchExpressionStatement();
        ForeachLoop();
    }

    private static void SwitchStatement()
    {
        PrintCurrentMethodName();
        TellMeAboutTheObject(DateTime.Now);
        TellMeAboutTheObject(0);
        TellMeAboutTheObject("Hello world");
        TellMeAboutTheObject(true);
    }
    
    private static void TellMeAboutTheObject(object obj)
    {
        switch (obj) 
        {
            case 0: // constant pattern
                Console.WriteLine("It's a zero.");
                break;
            case string str: // type pattern
                Console.WriteLine($"It's a string: {str}");
                break;
            // type pattern with case guard
            case DateTime dt when dt.DayOfWeek == DayOfWeek.Monday:
                Console.WriteLine("It's a Monday");
                break;
            default:
                Console.WriteLine("IDK");
                break;
        }
    }
    
    private static void SwitchExpressionStatement()
    {
        PrintCurrentMethodName();
        for (int i = 1; i <= 13; i++)
        {
            Console.WriteLine(GetCardName(i));
        }
    }

    private static string GetCardName(int cardNumber)
    {
        string cardName = cardNumber switch
        {
            13 => "King", // constant pattern
            12 => "Queen",
            11 => "Jack",
            > 1 and < 11 => "Pip card", // relational pattern
            1 => "Ace",
            // discard pattern, equivalent of default:
            _ => throw new ArgumentOutOfRangeException()
        };
        return cardName;
    }

    private static void ForeachLoop()
    {
        PrintCurrentMethodName();
        Span<int> span = new[] {0, 1, 2, 3, 4};
        foreach (ref int i in span)
        {
            i++;
        }

        foreach (int i in span)
        {
            Console.WriteLine(i);
        }

        foreach (char c in "foreach")
        {
            Console.WriteLine(c);
        }
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