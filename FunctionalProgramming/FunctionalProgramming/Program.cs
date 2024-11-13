using System.Diagnostics;

namespace FunctionalProgramming;

class Program
{
    static void Main(string[] args)
    {
        BinaryTreeTests();
        DictionaryTests();
        NumericsTests();
        BenchmarkingTests();
        FactoryMethodsTests();
    }
    
    private static void BinaryTreeTests()
    {
        PrintCurrentMethodName();
        var tree =
            new BinaryTree<int>(
                new BinaryTree<int>.Node(1,
                    new BinaryTree<int>.Node(2,
                        new BinaryTree<int>.Node(3,
                            new BinaryTree<int>.Node(4),
                            new BinaryTree<int>.Node(5))),
                    new BinaryTree<int>.Node(6,
                        null,
                        new BinaryTree<int>.Node(7,
                            new BinaryTree<int>.Node(8),
                            new BinaryTree<int>.Node(9,
                                new BinaryTree<int>.Node(10)))))
            );

        Console.WriteLine("Tree In-order:");
        tree.PrintInOrder();
    }
    
    private static void DictionaryTests()
    {
        PrintCurrentMethodName();
        var fruits = new List<string>
        {
            "banana", "apple", "apple", "orange", "apple", "dragon fruit", "orange", "apple", "orange",
            "avocado", "banana", "blackberry", "apple", "blackcurrant", "blueberry", "orange", "cherry",
            "apple", "durian", "grape", "banana", "apple", "kiwi", "lemon", "apple", "lime", "lychee",
            "mango", "melon", "mango", "nectarines", "orange", "passion fruit", "pear", "apple", "pineapple",
            "cherry", "strawberry", "orange", "lemon", "kiwi", "plum", "pear", "apple", "pineapple", "lemon",
            "plum", "pomegranate", "raspberry pi", "rhubarb", "banana", "strawberry", "tangerine", "watermelon",
            "nectarines", "plum", "pear", "pear", "kiwi", "apple", "pear", "apple", "apple", "lemon"
        };
        var counts = DictionaryExtensions.CountWords(fruits);
        Console.WriteLine("Fruit occurrences: ");
        foreach (var (fruit, count) in counts.OrderBy(t => -t.Value))
        {
            Console.WriteLine($"{fruit,-13} : {count,2}");
        }
    }
    
    private static void NumericsTests()
    {
        PrintCurrentMethodName();
        var l = Numerics.FindLinearRoot();
        var q = Numerics.FindQuadraticRoot();
        var s = Numerics.FindSinRoot();

        Console.WriteLine($"Linear function root: {l:#.####}");
        Console.WriteLine($"Quadratic function root: {q:#.####}");
        Console.WriteLine($"Sinus function root: {s:#.####}");
    }
    
    private static void BenchmarkingTests()
    {
        PrintCurrentMethodName();
        Console.WriteLine("Running benchmarks:");
        foreach (var benchmark in Benchmarking.CreateBenchmarks())
        {
            benchmark();
        }
    }
    
    private static void FactoryMethodsTests()
    {
        PrintCurrentMethodName();
        var piEstimation = FactoryMethods.MonteCarloPiEstimation();
        Console.WriteLine($"PI estimation: {piEstimation:#.####}");
        Console.WriteLine($"Error: {Math.Abs(piEstimation - Math.PI)}");
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