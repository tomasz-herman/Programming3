using System.Runtime.CompilerServices;

namespace Tuples;

class Program
{
    static void Main(string[] args)
    {
        TuplesIntroduction();
        NamingTupleElements();
        BackingType();
        TupleEquality();
    }

    private static void TuplesIntroduction()
    {
        PrintCurrentMethodName();
        (double, int) t1 = (4.5, 3);
        Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");

        (double Sum, int Count) t2 = (4.5, 3);
        Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
    }

    private static void NamingTupleElements()
    {
        PrintCurrentMethodName();
        {
            var t = (Sum: 4.5, Count: 3);
            Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");
            (double Sum, int Count) d = (4.5, 3);
            Console.WriteLine($"Sum of {d.Count} elements is {d.Sum}.");
        }

        {
            var sum = 4.5;
            var count = 3;
            var t = (sum, count);
            Console.WriteLine($"Sum of {t.count} elements is {t.sum}.");
        }

        {
            var a = 1;
            var t = (a, b: 2, 3);
            Console.WriteLine($"The 1st element is {t.Item1} ({t.a}).");
            Console.WriteLine($"The 2nd element is {t.Item2} ({t.b}).");
            Console.WriteLine($"The 3rd element is {t.Item3}.");
        }
    }
    
    private static void BackingType()
    {
        PrintCurrentMethodName();
        ValueTuple<string, int> bob = ("Bob", 23);
        (string, int) alice = ("Alice", 42);
        (string name, int age) chad = ValueTuple.Create("Chad", 19);
        alice = bob = chad;
    }

    private static void TupleEquality()
    {
        PrintCurrentMethodName();
        (int a, byte b) left = (5, 10);
        (long a, int b) right = (5, 10);
        Console.WriteLine(left == right);  // output: True
        Console.WriteLine(left != right);  // output: False

        var t1 = (A: 5, B: 10);
        var t2 = (B: 5, A: 10);
        Console.WriteLine(t1 == t2);  // output: True
        Console.WriteLine(t1 != t2);  // output: False
    }

    private static void TupleDeconstruction()
    {
        PrintCurrentMethodName();
        var bob = ("Bob", 23);
        {
            (string name, int age) = bob;
            Console.WriteLine($"Person name is {name}, age is {age}.");
        }
        {
            string name; int age;
            (name, age) = bob;
            Console.WriteLine($"Person name is {name}, age is {age}.");
        }
        {
            var (name, age) = bob;
            Console.WriteLine($"Person name is {name}, age is {age}.");
        }
    }

    private static void PrintCurrentMethodName([CallerMemberName] string caller = "")
    {
        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {caller,27} *");
        Console.WriteLine("***************************************");
    }
}