using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace VariablesAndParameters;

public static class Program
{
    private static void Main()
    {
        DefiniteAssignment();
        DefaultValues();
        PassingParametersByValue();
        PassingParametersByReference();
        OutParameters();
        InParameters();
        VariableNumberOfParameters();
        OptionalAndNamedParameters();
        ReferenceVariables();
        ReferenceReturn();
        ImplicitlyTypedLocalVariables();
    }

    private static void DefiniteAssignment()
    {
        PrintCurrentMethodName();
        int x, y;
        Console.WriteLine($"Variables needs to be initialized before accessing.");
        // Console.WriteLine(x); // Compilation error, 'x' might not be initialized before accessing
        if (Random.Shared.NextDouble() < 0.5)
        {
            x = y = 1;
            Console.WriteLine($"Both variables might be accessed here: x = {x}, y = {y}");
        }
        else
        {
            y = 0;
        }

        Console.WriteLine($"Only Y can be accessed here y = {y}");
        Console.WriteLine("X needs to be definitely assigned to be accessed here");
        // Console.WriteLine(x); // Compilation error, 'x' might not be initialized before accessing

        int[] a = new int[10];
        Console.WriteLine($"Array contents are initialized with default values, e.g a[2] = {a[2]}");

        Test test = new Test();
        Console.WriteLine($"Class/Struct contents are also initialized with defaults, e.g test.X = {test.X}");
    }

    private class Test { public int X { get; set; } }

    private static void DefaultValues()
    {
        PrintCurrentMethodName();
        Console.WriteLine("default operator returns default value");
        Console.WriteLine("basically its a value with all bits set to 0");
        float x = default;
        Console.WriteLine(default(float));
        Console.WriteLine(default(DateTime));
        Console.WriteLine(default(string) ?? "null");
    }

    private static void PassingParametersByValue()
    {
        PrintCurrentMethodName();
        int x = 8;
        IncrementAndPrint(x);
        Console.WriteLine($"After IncrementAndPrint: {x}");

        StringBuilder sb = new StringBuilder();
        AppendAndNullify(sb);
        Console.WriteLine($"String builder is now: {sb}");
    }

    private static void IncrementAndPrint(int value)
    {
        value = value + 1;
        Console.WriteLine($"Inside IncrementAndPrint: {value}");
    }

    private static void AppendAndNullify(StringBuilder builder)
    {
        builder.Append("test");
        builder = null;
    }
    
    private static void PassingParametersByReference()
    {
        PrintCurrentMethodName();
        int x = 8;
        IncrementAndPrint(ref x);
        Console.WriteLine($"After IncrementAndPrint: {x}");

        StringBuilder sb = new StringBuilder();
        AppendAndNullify(ref sb);
        Console.WriteLine($"String builder is now: {sb}");
    }

    private static void IncrementAndPrint(ref int value)
    {
        value = value + 1;
        Console.WriteLine($"Inside IncrementAndPrint: {value}");
    }

    private static void AppendAndNullify(ref StringBuilder builder)
    {
        builder.Append("test");
        builder = null;
    }

    private static void OutParameters()
    {
        PrintCurrentMethodName();
        string[] tblFirstNames; string tblLastName;
        GetFirstAndLastNames("Tim Berners Lee", out tblFirstNames, out tblLastName);
        GetFirstAndLastNames("John Fitzgerald Kennedy", out string[] jfkFirstsNames, out string jfkLastName);
        GetFirstAndLastNames("Julius Robert Oppenheimer", out var jroFirstNames, out _);

        Console.WriteLine($"Tim Berners Lee: {string.Join(" ", tblFirstNames)} {tblLastName}");
        Console.WriteLine($"John Fitzgerald Kennedy: {string.Join(" ", jfkFirstsNames)} {jfkLastName}");
        Console.WriteLine($"Julius Robert Oppenheimer: {string.Join(" ", jroFirstNames)} (last name discarded)");
    }
    
    private static void GetFirstAndLastNames(string name, out string[] firstNames, out string lastName)
    {
        string[] words = name.Split(' ');
        firstNames = words[..^1];
        lastName = words[^1];
    }
    
    private static void InParameters()
    {
        PrintCurrentMethodName();
        Matrix4 a = Matrix4.CreateRotationX(60.0f);
        Matrix4 b = Matrix4.CreateRotationY(45.0f);
        Multiply(in a, in b, out var result);
        Console.WriteLine(result);
    }
    
    private static void Multiply(in Matrix4 a, in Matrix4 b, out Matrix4 result)
    {
        // a.M11 = 0.0f; // Cannot change a or b, results in a compile-time error
        result = new Matrix4
        {
            M11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
            M12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
            M13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
            M14 = a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,

            M21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
            M22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
            M23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
            M24 = a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,

            M31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
            M32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
            M33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
            M34 = a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,

            M41 = a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
            M42 = a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
            M43 = a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
            M44 = a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44
        };
    }

    private static void VariableNumberOfParameters()
    {
        PrintCurrentMethodName();
        string s1 = Concat("The", "Quick", "Brown", "Fox");
        string s2 = Concat("Jumps", "Over", "The", "Lazy", "Dog");
        Console.WriteLine(Concat(s1, s2));
        Concat("This function accepts at least 1 parameter");
    }

    private static string Concat(string str, params string[] strings)  
    {
        StringBuilder sb = new StringBuilder(str);
        foreach (string s in strings)
        {
            sb.Append(s);
        }
        return sb.ToString();
    }
    
    private static void OptionalAndNamedParameters()
    {
        PrintCurrentMethodName();
        ExampleMethod(3, "parameter", 7);
        ExampleMethod(3, "parameter");
        ExampleMethod(3);
        ExampleMethod(3, optionalInt: 4);
    }

    private static void ExampleMethod(int required, string optionalStr = "default value", int optionalInt = 0)
    {
        Console.WriteLine($"Required int: {required}, optional str: {optionalStr}, optional int: {optionalInt}");
    }

    private static void ReferenceVariables()
    {
        PrintCurrentMethodName();
        int[] storage = [1, 30, 7, 1557, 381];
        ref int intRef = ref storage[3];
        intRef = 20;
        Console.WriteLine($"IntRef = {intRef}");
        Console.WriteLine($"Storage[3] = {storage[3]}");
    }

    private static void ReferenceReturn()
    {
        PrintCurrentMethodName();
        var storage = new IntStorage();
        ref int max = ref storage.GetMax();
        Console.WriteLine($"Storage = {storage}");
        max = -1;
        Console.WriteLine($"Storage = {storage} (after change)");
    }

    private class IntStorage
    {
        private int[] _storage = [1, 30, 7, 1557, 381];

        public ref int GetMax()
        {
            ref int max = ref _storage[0];
            for (int i = 1; i < _storage.Length; i++)
                if (_storage[i] > max) 
                    max = ref _storage[i];
            return ref max;
        }

        public override string ToString() => string.Join(", ", _storage);
    }

    private static void ImplicitlyTypedLocalVariables()
    {
        PrintCurrentMethodName();
        var greeting = "Hello";
        var i = 0;
        var x = 0.15f;
        var list = new List<int>();
        var dayOfWeek = DateTime.Now.DayOfWeek;
        var ints = new[] { 1, 2, 3, 4, 5 };
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void PrintCurrentMethodName()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);

        Console.WriteLine("********************************************");
        Console.WriteLine($"* Method: {sf!.GetMethod()!.Name,32} *");
        Console.WriteLine("********************************************");
    }
}