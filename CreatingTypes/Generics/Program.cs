using System.Diagnostics;

namespace Generics;

public static class Program
{
    private static void Main(string[] args)
    {
        GenericsExample();
        WhyGenerics();
        GenericsConstraints();
        GenericsVariance();
    }

    private static void GenericsExample()
    {
        PrintCurrentMethodName();
        Stack<int> intStack = new Stack<int>();
        for (int i = 0; i < 10; i++)
        {
            intStack.Push(i);
        }

        while (intStack.Count > 0)
        {
            int item = intStack.Pop();
            Console.Write(item);
        }

        Console.WriteLine();
        
        Stack<string> strStack = new Stack<string>();
        string[] strArray = ["Quick", "fox", "jumped", "over", "the", "lazy", "dog"];
        foreach (var str in strArray)
        {
            strStack.Push(str);
        }

        while (strStack.Count > 0)
        {
            string item = strStack.Pop();
            Console.Write(item);
        }

        Console.WriteLine();
    }
    
    private static void WhyGenerics()
    {
        PrintCurrentMethodName();
        ObjectStack intStack = new ObjectStack();
        for (int i = 0; i < 10; i++)
        {
            intStack.Push(i);
        }

        while (intStack.Count > 0)
        {
            int item = (int)intStack.Pop();
            Console.Write(item);
        }

        Console.WriteLine();
        
        ObjectStack strStack = new ObjectStack();
        string[] strArray = ["Quick", "fox", "jumped", "over", "the", "lazy", "dog"];
        foreach (var str in strArray)
        {
            strStack.Push(str);
        }

        while (strStack.Count > 0)
        {
            string item = (string)strStack.Pop();
            Console.Write(item);
        }

        Console.WriteLine();
    }

    private static void GenericsConstraints()
    {
        PrintCurrentMethodName();
        Console.WriteLine(MathUtils.Max(1, 5, 2, -4, 0, 210, 42));
        Console.WriteLine(MathUtils.Max("the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"));
        // Compile time error, trees are not comparable:
        // Console.WriteLine(MathUtils.Max(new Apple(), new Orange(), new Orange(), new Orange(), new Apple(), new Apple()));
    }

    private static void GenericsVariance()
    {
        PrintCurrentMethodName();
        // Covariance allows down-casting generic type
        var apples = new VariantStack<AppleTree>();
        apples.Push(new AppleTree());
        apples.Push(new AppleTree());
        IPoppable<Tree> poppableTrees = apples;

        // Contravariance allows up-casting generic type
        var trees = new VariantStack<Tree>();
        trees.Push(new AppleTree());
        trees.Push(new OrangeTree());
        IPushable<AppleTree> pushableApples = trees;
    }

    private abstract class Tree;
    private class AppleTree : Tree;
    private class OrangeTree : Tree;

    private static void PrintCurrentMethodName()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);

        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {sf!.GetMethod()!.Name,27} *");
        Console.WriteLine("***************************************");
    }
}