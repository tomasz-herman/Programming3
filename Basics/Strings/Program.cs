using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Strings;

public class Program
{
    private static void Main()
    {
        StringsShowcase();
        StringPropertiesAndMethods();
        VerbatimStrings();
        RawStrings();
        StringInterpolation();
        MutableStrings();
        MutableStringsPerformance();
    }

    private static void StringsShowcase()
    {
        PrintCurrentMethodName();
        string text = "Just a text";
        Console.WriteLine("Equality operator follows value type semantics: " + (text == "Just a text"));
        string greeting = "Hello World!\n";
        greeting += "This is a string showcase";
        Console.WriteLine(greeting);
    }

    private static void StringConstructors()
    {
        PrintCurrentMethodName();
        char[] chars = ['w', 'o', 'r', 'l', 'd'];
        string fromLiteral = "Hello";
        string fromArray = new string(chars);
        string repeatedChar = new string(' ', 4);
        string fromSubArray = new string(chars, 1, 2);

        Console.WriteLine($"{fromLiteral} {fromArray} {repeatedChar} {fromSubArray}");
    }

    private static void StringPropertiesAndMethods()
    {
        PrintCurrentMethodName();
        string greeting = "Hello, World!\n";
        
        Console.WriteLine("string Length property: " + greeting.Length);
        
        char space = greeting[6];
        // greeting[6] = '_'; // compilation error, indexer is read-only

        foreach (char c in greeting)
        {
            Console.Write(c);
        }

        string substring = greeting.Substring(7, 5);
        Console.WriteLine($"Substring: {substring}");

        bool contains = greeting.Contains("World");
        Console.WriteLine($"Contains 'World': {contains}");
        
        string replaced = greeting.Replace("World", "Class");
        Console.WriteLine($"Replace: {replaced}");

        string upper = greeting.ToUpper();
        Console.WriteLine($"Uppercase: {upper}");

        string[] words = greeting.Split(' ');
        Console.WriteLine("Split:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        string joined = string.Join(" ", words);
        Console.WriteLine(joined);
    }
    
    private static void VerbatimStrings()
    {
        PrintCurrentMethodName();
        string path = @"C:\Users\tomasz\Documents\";
        Console.WriteLine(path);
        string text = @"My pensive SARA ! thy soft cheek reclined
                Thus on mine arm, most soothing sweet it is
                To sit beside our Cot,...";
        Console.WriteLine(text);
        string quote = @"Her name was ""Sara.""";
        Console.WriteLine(quote);
    }
    
    private static void RawStrings() // C# 11
    {
        PrintCurrentMethodName();
        var str1 = """
                   This is a "raw string literal".
                   """;
        Console.WriteLine(str1);
        var str2 = """It can contain characters like \, ' and ".""";
        Console.WriteLine(str2);
        var xml = """
                  <element attr="content">
                      <body>
                      </body>
                  </element>
                  """;
        Console.WriteLine(xml);
        var str3 = """"
                   """Raw string literals""" can start 
                   and end with more than three 
                   double-quotes when needed.
                   """";
        Console.WriteLine(str3);
    }
    
    private static void StringInterpolation()
    {
        PrintCurrentMethodName();
        string author = "George Orwell";
        string book = "Nineteen Eighty-Four";
        int year = 1949;
        decimal price = 19.50m;
        string description = $"{author} is the author of {book}. \n" +
                             $"The book price is {price:C}, it was published in {year}.";
        Console.WriteLine(description);

        Console.WriteLine($"Number 1: {1.0,10:C}");
        Console.WriteLine($"Number 2: {12.5,10:C}");
        Console.WriteLine($"Number 3: {123.45m,10:C}");

        var random = new Random();
        Console.WriteLine(
            $"Coin flip: {(random.NextDouble() < 0.5 ? "heads" : "tails"),9}"
        );
    }

    private static void MutableStrings()
    {
        PrintCurrentMethodName();
        StringBuilder stringBuilder = new StringBuilder("Hello, ");
            
        stringBuilder.Append("this is ");
        stringBuilder.Append("a simple ");
        stringBuilder.Append("StringBuilder demo.");
        stringBuilder.Append(" Goodbye!");

        Console.WriteLine(stringBuilder.ToString());
    }
    
    private static void MutableStringsPerformance()
    {
        PrintCurrentMethodName();
        const int iterations = 100_000;
        Stopwatch sw = Stopwatch.StartNew();
        string str = "";
        for (int i = 0; i < iterations; i++)
        {
            str += 'a';
        }
        sw.Stop();
        Console.WriteLine($"Operator +, took: {sw.ElapsedMilliseconds} ms");

        sw = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append('a');
        }
        sw.Stop();
        Console.WriteLine($"StringBuilder took: {sw.ElapsedMilliseconds} ms");
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