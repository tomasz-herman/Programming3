using System.Diagnostics;

namespace Nullable;

public static class Program
{
#nullable disable
    private static void Main(string[] args)
    {
        NullCoalescingOperator();
        NullCoalescingAssignmentOperator();
        NullConditionalOperator();
        NullableValueTypes();
        NullableValueConversions();
        NullableLiftingOperators();
        NullableBoolLogic();
        NullableReferenceTypes();
        NullForgivingOperator();
    }

    private static void NullCoalescingOperator()
    {
        PrintCurrentMethodName();
        string s1 = null;
        string s2 = s1 ?? "non-null";
        Console.WriteLine($"Value of s2: {s2}");
        // equivalent:
        // string s2 = (s1 == null) ? "non-null": s1;
        
        // Can also throw exception if s1 is null:
        // s2 = s1 ?? throw new ArgumentNullException();
    }

    private static void NullCoalescingAssignmentOperator()
    {
        PrintCurrentMethodName();
        string s = null;
        s ??= "non-null";
        Console.WriteLine($"Value of s: {s}");

        // equivalent:
        // string s = (s == null) ? "non-null" : s;
    }

    private static void NullConditionalOperator()
    {
        PrintCurrentMethodName();
        System.Text.StringBuilder sb = null;
        string s = sb?.ToString();
        Console.WriteLine($"Value of s: {s}");

        // equivalent:
        // string s = (sb == null ? null : sb.ToString());
    }

    private static void NullableValueTypes()
    {
        PrintCurrentMethodName();
        // Cannot assign null to a value types:
        // int integer = null; // Compile-time error

        // Can assign null to a nullable value type (denoted with ?)
        int? i = null;
        Console.WriteLine (i == null); // True
        
        // Equivalent:
        // Nullable<int> i = null;
        // Console.WriteLine (!i.HasValue); // True
    }

    private static void NullableValueConversions()
    {
        PrintCurrentMethodName();
        int? i = 5;      // implicit conversion
        int j = (int)i;  // explicit conversion (might throw if `i` is null)

        Equivalent:
        // int j = i.Value;
        Console.WriteLine($"The value of j is: {j}");
    }

    private static void NullableLiftingOperators()
    {
        PrintCurrentMethodName();
        int? x = 5;
        int? y = null;
        // Equality operator examples
        Console.WriteLine(x == y);    // false
        Console.WriteLine(x == null); // false
        Console.WriteLine(x == 5);    // true
        Console.WriteLine(y == null); // true
        Console.WriteLine(y == 5);    // false
        Console.WriteLine(y != 5);    // true
        // Relational operator examples
        Console.WriteLine(x < 6);     // true
        Console.WriteLine(y < 6);     // false
        Console.WriteLine(y > 6);     // false
        // All other operator examples
        Console.WriteLine(x + 5);     // 10
        Console.WriteLine(x + y);     // null
    }
    
    private static void NullableBoolLogic()
    {
        PrintCurrentMethodName();
        bool? n = null;
        bool? f = false;
        bool? t = true;
        Console.WriteLine (n | n); // null
        Console.WriteLine (n | f); // null
        Console.WriteLine (n | t); // true
        Console.WriteLine (n & n); // null
        Console.WriteLine (n & f); // false
        Console.WriteLine (n & t); // null
    }

#nullable enable
    private static void NullableReferenceTypes()
    {
        PrintCurrentMethodName();
        string s1 = null;  // Generates a compiler warning
        string? s2 = null; // OK: s2 is nullable reference type
    }
    
    class Foo
    {
        // Also a warning, since x is not initialized
        string x;
    }
    
    private static void NullForgivingOperator()
    {
        PrintCurrentMethodName();
        string s1 = null!;         // `!` Silences the warning
        string? s2 = null;
        int s2Length = s2!.Length; // `!` Silences the warning
            
        // Either is better (exception-safe):
        // int? s2Length2 = s2?.Length;
        // if (s2 != null) Console.Write(s2.Length);
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