using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PerformanceCSharp;

public partial class Program
{
    [LibraryImport("PerformanceCpp")]
    public static partial int Add(int a, int b);
    
    [LibraryImport("PerformanceCpp")]
    public static partial int AddBatch(int baseValue, int times);
    
    public static int AddManaged(int a, int b)
    {
        return a + b;
    }
    
    public static int AddBatchManaged(int baseValue, int times)
    {
        for (int i = 0; i < times; i++)
        {
            baseValue = AddManaged(baseValue, 1);
        }

        return baseValue;
    }
    
    private static void Main()
    {
        int times = 1_000_000_000;
        var sw = Stopwatch.StartNew();

        int sum = 0;
        for (int i = 0; i < times; i++)
        {
            sum = Add(sum, 1);
        }
        
        sw.Stop();
        Console.WriteLine($"Sum: {sum}, time (C++) = {sw.ElapsedMilliseconds}ms");
        
        sw = Stopwatch.StartNew();

        sum = 0;
        for (int i = 0; i < times; i++)
        {
            sum = AddManaged(sum, 1);
        }
        
        sw.Stop();
        Console.WriteLine($"Sum: {sum}, time (C#) = {sw.ElapsedMilliseconds}ms");
        
        sw = Stopwatch.StartNew();

        sum = AddBatch(0, times);
        
        sw.Stop();
        Console.WriteLine($"Sum: {sum}, time (C++ batched) = {sw.ElapsedMilliseconds}ms");
        
        sw = Stopwatch.StartNew();

        sum = AddBatchManaged(0, times);

        sw.Stop();
        Console.WriteLine($"Sum: {sum}, time (C# batched) = {sw.ElapsedMilliseconds}ms");
    }
}