using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace CustomAttributes;

public static class Program
{
    public static void Main()
    {
        var methods = typeof(Program)
            .GetMethods(BindingFlags.Public | BindingFlags.Static);
        foreach (var method in methods)
        {
            BenchmarkAttribute? attribute = method
                .GetCustomAttributes<BenchmarkAttribute>()
                .FirstOrDefault();
            if (attribute != null)
            {
                Action? action = (Action?)Delegate.CreateDelegate(typeof(Action), method, false);
                if (action is null)
                {
                    Console.WriteLine($"Method {method.Name} needs to take no parameters, and return void.");
                    continue;
                }

                int rep = attribute.Repetitions;
                Console.WriteLine($"Found benchmark: {method.Name}");
                Console.WriteLine($"Calling it {attribute.Repetitions} times");
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < rep; i++)
                {
                    action();
                }
                sw.Stop();
                double micro = sw.Elapsed.TotalNanoseconds / rep / 1000;
                Console.WriteLine($"{method.Name} time: {micro:0}μs");
            }
        }
    }

    [Benchmark]
    public static void StringAdd()
    {
        string _ = "";
        for (int i = 0; i < 10_000; i++)
        {
            _ += 'a';
        }
    }
    
    [Benchmark(10000)]
    public static void StringBuilder()
    {
        StringBuilder a = new StringBuilder();
        for (int i = 0; i < 10_000; i++)
        {
            a.Append('a');
        }

        string _ = a.ToString();
    }
    
    [Benchmark()]
    public static void StringJoin()
    {
        string _ = string.Join(string.Empty, Enumerable.Repeat('a', 10_000));
    }

    private static void PrintCurrentMethodName([CallerMemberName] string caller = "")
    {
        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {caller,27} *");
        Console.WriteLine("***************************************");
    }
}