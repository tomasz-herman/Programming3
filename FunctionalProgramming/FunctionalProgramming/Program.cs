// #define SHOP

using System.Diagnostics;
#if SHOP
using FunctionalProgramming.Events;
#endif

namespace FunctionalProgramming;

class Program
{
    static void Main()
    {
        BinaryTreeTests();
        DictionaryTests();
        NumericsTests();
        BenchmarkingTests();
        FactoryMethodsTests();
        #if SHOP
        ShopTests();
        #endif
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
    
    #if SHOP
    private static void ShopTests()
    {
        PrintCurrentMethodName();
        Shop shop = new Shop();
        List<Product> delivery1 = new List<Product>
        {
            new ("Banana", 2.99m, 100),
            new ("Apple", 1.99m, 100),
            new ("Orange", 3.99m, 100),
            new ("Flour", 1.29m, 60),
            new ("Sugar", 2.19m, 60),
            new ("Milk", 2.49m, 48),
        };
        List<Product> delivery2 = new List<Product>
        {
            new ("Flour", 1.49m, 30),
            new ("Sugar", 2.09m, 30),
            new ("Milk", 2.49m, 24),
        };
        
        // 
        // Adding a Product to the Shop should trigger the ElementAdded event, notifying about the new product via ElementChangedEventArgs.
        // Removing a Product from the Shop should trigger the ElementRemoved event, notifying when a product has been removed via ElementChangedEventArgs.
        // Changing a Product's Property (like Price or Quantity) should trigger the ElementPropertyChanged event, notifying about the change.
        //
        
        Console.WriteLine("Initial delivery...");
        delivery1.ForEach(product => shop.Add(product));
        Console.WriteLine("Simulating shopping day...");
        delivery1[1].Quantity -= 20;
        delivery1[3].Quantity -= 20;
        delivery1[3].Quantity -= 40;
        delivery1[4].Quantity -= 20;
        delivery1[4].Quantity -= 30;
        delivery1[4].Quantity -= 10;
        delivery1[0].Quantity -= 20;
        delivery1[5].Quantity -= 12;
        delivery1[5].Quantity -= 12;
        delivery1[5].Quantity -= 12;
        delivery1[2].Quantity -= 20;
        delivery1[5].Quantity -= 12;
        Console.WriteLine("Restock...");
        delivery2.ForEach(product => shop.Add(product));
        Console.WriteLine("Simulating shopping day...");
        delivery1[3].Quantity -= 20;
        delivery1[4].Quantity -= 20;
        delivery1[4].Quantity -= 10;        
        delivery1[1].Quantity -= 20;
        delivery1[5].Quantity -= 12;
        delivery1[5].Quantity -= 12;
        Console.WriteLine("Cleaning aisles...");
        shop.CleanAisles();
    }
    #endif
    
    private static void PrintCurrentMethodName()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);

        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {sf!.GetMethod()!.Name,27} *");
        Console.WriteLine("***************************************");
    }
}

// SOLUTION:
// shop.ElementAdded += (_, args) =>
// {
//     Console.WriteLine($"New Product available {args.Element}");
// };
//
// shop.ElementRemoved += (_, args) =>
// {
//     Console.WriteLine($"{args.Element.Name} is no longer available");
// };
//
// shop.ElementPropertyChanged += (_, args) =>
// {
//     var value = args.PropertyName switch
//     {
//         nameof(Product.Price) => $"{args.Element.Price:C}",
//         nameof(Product.Quantity) => $"{args.Element.Quantity}",
//         _ => "Unknown"
//     };
//
//     Console.WriteLine($"Product {args.Element.Name} changed, new {args.PropertyName} = {value}");
// };