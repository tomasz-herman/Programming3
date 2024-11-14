using System.Diagnostics;

namespace PatternMatching;

public static class Program
{
    static void Main()
    {
        PatternMatching();
        TypeAndDeclarationPatterns();
        ConstantPattern();
        RelationalPattern();
        LogicalPattern();
        PropertyPattern();
        PositionalPattern();
        VarPattern();
        DiscardPattern();
        ListPattern();
        ListSlicePattern();
    }

    private static void PatternMatching()
    {
        PrintCurrentMethodName();
        Console.WriteLine($"Today is working day: {IsWorkingDay(DateTime.Now)}");
    }
    
    public static bool IsWorkingDay(object date)
    {
        if (date is null) throw new ArgumentNullException();
        if (date is DateTime dateTime)
        {
            if (dateTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }

        return date is DateOnly
        {
            DayOfWeek: not (DayOfWeek.Saturday or DayOfWeek.Sunday)
        };
    }

    private static void TypeAndDeclarationPatterns()
    {
        PrintCurrentMethodName();
        Console.WriteLine($"Car toll = {CalculateToll(new Car())}");
        Console.WriteLine($"Truck toll (load 60) = {CalculateToll(new Truck {Load = 60})}");
        Console.WriteLine($"Truck toll (load 120) = {CalculateToll(new Truck {Load = 120})}");
    }

    public abstract class Vehicle;
    public class Car : Vehicle;
    public class Truck : Vehicle { public float Load { get; init; } }

    public static decimal CalculateToll(Vehicle vehicle) => vehicle switch
    {
        Car => 2.00m,
        Truck truck => truck.Load > 100 ? 17.50m : 7.50m,
        _ => throw new ArgumentException(),
    };

    private static void ConstantPattern()
    {
        PrintCurrentMethodName();
        string? input = null;
        if (input is null) { }

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Group ticket price for {i} people: {GetGroupTicketPrice(3)}");
        }
    }
    
    static decimal GetGroupTicketPrice(int visitorCount) => visitorCount switch
    {
        1 => 12.0m,
        2 => 20.0m,
        3 => 27.0m,
        4 => 32.0m,
        0 => 0.0m,
        _ => throw new ArgumentException(),
    };

    private static void RelationalPattern()
    {
        PrintCurrentMethodName();
        Console.WriteLine($"Today is: {GetCalendarSeason(DateTime.Now)}");
    }
    
    static string GetCalendarSeason(DateTime date) => date.Month switch
    {
        >= 3 and < 6 => "spring",
        >= 6 and < 9 => "summer",
        >= 9 and < 12 => "autumn",
        12 or (>= 1 and < 3) => "winter",
        _ => throw new ArgumentOutOfRangeException()
    };

    private static void LogicalPattern()
    {
        PrintCurrentMethodName();
        string? input = null;
        if (input is not null) { /**/ }

        Console.WriteLine($"Is 'A' letter: {IsLetter('A')}");
        Console.WriteLine($"Is '#' letter: {IsLetter('#')}");
        Console.WriteLine($"Is '2' letter: {IsLetter('2')}");
    }
    
    static bool IsLetter(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');

    private static void PropertyPattern()
    {
        PrintCurrentMethodName();
        Console.WriteLine($"Is today a conference? {IsConferenceDay(DateTime.Today)}");
        Console.WriteLine($"Take five from string: {TakeFive("Hello, world")}");
        Console.WriteLine($"Take five from array: {TakeFive(new [] { 'H', 'e', 'l', 'l', 'o', '.'})}");
    }
    
    static bool IsConferenceDay(DateTime date) => 
        date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };
        
    static string TakeFive(object input) => input switch
    {
        string { Length: >= 5 } s => s.Substring(0, 5),
        string s => s,

        ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
        ICollection<char> symbols => new string(symbols.ToArray()),

        null => throw new ArgumentNullException(),
        _ => throw new ArgumentException(),
    };
    
    private static void PositionalPattern()
    {
        PrintCurrentMethodName();
        Console.WriteLine($"Point (0, 0): {Classify(new Point(0, 0))}");
        Console.WriteLine($"Point (0, 1): {Classify(new Point(0, 1))}");
        Console.WriteLine($"Point (1, 0): {Classify(new Point(1, 0))}");
        Console.WriteLine($"Point (1, 1): {Classify(new Point(1, 0))}");
    }
    
    public readonly struct Point(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;

        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }

    static string Classify(Point point) => point switch
    {
        (0, 0) => "Origin",
        (> 0, 0) => "positive X basis end",
        (0, > 0) => "positive Y basis end",
        _ => "Just a point",
    };

    private static void VarPattern()
    {
        PrintCurrentMethodName();
        Console.WriteLine($"Is data acceptable: {IsAcceptable(5, 10)}");
    }
    
    static bool IsAcceptable(int count, int absLimit) =>
        SimulateDataFetch(count) is var results 
        && results.Min() >= -absLimit 
        && results.Max() <= absLimit;

    static int[] SimulateDataFetch(int count)
    {
        var rand = new Random();
        return Enumerable
            .Range(start: 0, count: count)
            .Select(_ => rand.Next(minValue: -10, 
                maxValue: 11))
            .ToArray();
    }

    private static void DiscardPattern()
    {
        PrintCurrentMethodName();
        Console.WriteLine($"Discount on {DayOfWeek.Monday}: {GetDiscountInPercent(DayOfWeek.Monday)}");
        Console.WriteLine($"Discount on {(DayOfWeek)8}: {GetDiscountInPercent((DayOfWeek)8)}");
        Console.WriteLine($"Discount on {null}: {GetDiscountInPercent(null)}");
    }
    
    static decimal GetDiscountInPercent(DayOfWeek? dayOfWeek) => dayOfWeek switch
    {
        DayOfWeek.Monday => 0.5m,
        DayOfWeek.Tuesday => 12.5m,
        DayOfWeek.Wednesday => 7.5m,
        DayOfWeek.Thursday => 12.5m,
        DayOfWeek.Friday => 5.0m,
        DayOfWeek.Saturday => 2.5m,
        DayOfWeek.Sunday => 2.0m,
        _ => 0.0m,
    };
    
    private static void ListPattern()
    {
        PrintCurrentMethodName();
        int[] numbers = { 1, 2, 3 };

        Console.WriteLine(numbers is [1, 2, 3]);
        Console.WriteLine(numbers is [1, 2, 4]);
        Console.WriteLine(numbers is [1, 2, 3, 4]);
        Console.WriteLine(numbers is [0 or 1, <= 2, >= 3]);
        
        List<int> list = new() { 1, 2, 3 };

        if (list is [var first, _, _])
        {
            Console.WriteLine(
                $"The first element of a three-item list is {first}.");
        }
    }
    
    private static void ListSlicePattern()
    {
        PrintCurrentMethodName();
        Console.WriteLine(new[]{ 1, 2, 3, 4 } is [>= 0, .., 2 or 4]);
        Console.WriteLine(new[]{ 1, 0, 0, 1 } is [1, 0, .., 0, 1]);
        Console.WriteLine(new[]{ 1, 0, 1 } is [1, 0, .., 0, 1]);
        string greeting = "Hello world";
        if (greeting is ['H', .. var rest])
            Console.WriteLine(rest);

        Console.WriteLine(Validate([-1, 0, 1]));
        Console.WriteLine(Validate([-1, 0, 0, 1]));
    }
    
    private static string Validate(int[] numbers)
    {
        return numbers is 
            [< 0, .. { Length: 2 or 4 }, > 0] ? 
            "valid" : "not valid";
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