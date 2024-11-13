using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace FunctionalProgramming;

/// <summary>
/// Creates a benchmarking wrapper around a given Action to measure and report the average execution time 
/// over a specified number of iterations. The method measures the time using the <see cref="Stopwatch"/> class.
/// </summary>
/// <param name="action">
/// The Action delegate representing the code to be benchmarked.
/// </param>
/// <param name="name">
/// A string representing the name of the benchmark to include in the output.
/// </param>
/// <param name="times">
/// An optional integer specifying the number of iterations (default is 1000).
/// </param>
/// <returns>
/// An Action delegate that, when invoked, benchmarks the provided action by executing it `times` times 
/// and calculates the average time per execution in milliseconds.
/// </returns>
/// <remarks>
/// The returned Action measures the time it takes to execute the provided action a specified number of times 
/// and prints the average time in the following format:
/// <code>
/// "Function `name`: `elapsed` ms on average"
/// </code>
/// Example usage:
/// <code>
/// Action benchmark = CreateBenchmark(ExampleFunction, "ExampleFunction", times: 500);
/// benchmark(); // Prints the average execution time for ExampleFunction
/// </code>
/// The <see cref="Stopwatch"/> is used for precise timing:
/// - <see cref="Stopwatch.Start"/>
/// - <see cref="Stopwatch.Stop"/>
/// - <see cref="Stopwatch.Elapsed.TotalMilliseconds"/>
/// </remarks>
public static class Benchmarking
{
    private const int Size = 1_000;

    public static void StringAdd()
    {
        string _ = String.Empty;
        for (int i = 0; i < Size; i++)
        {
            _ += 'a';
        }
    }

    public static void StringBuilder()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Size; i++)
        {
            sb.Append('a');
        }

        string _ = sb.ToString();
    }

    public static void StringJoin()
    {
        string _ = string.Join(string.Empty, Enumerable.Repeat('a', Size));
    }

    // TODO: CreateBenchmark

    public static IEnumerable<Action> CreateBenchmarks()
    {
        // TODO: CreateBenchmarks
        return ImmutableList.Create(StringAdd, StringBuilder, StringJoin);
    }
}

// SOLUTION
// public static class Benchmarking
// {
//     private const int Size = 1_000;
//
//     public static void StringAdd()
//     {
//         string _ = String.Empty;
//         for (int i = 0; i < Size; i++)
//         {
//             _ += 'a';
//         }
//     }
//
//     public static void StringBuilder()
//     {
//         StringBuilder sb = new StringBuilder();
//         for (int i = 0; i < Size; i++)
//         {
//             sb.Append('a');
//         }
//
//         string _ = sb.ToString();
//     }
//
//     public static void StringJoin()
//     {
//         string _ = string.Join(string.Empty, Enumerable.Repeat('a', Size));
//     }
//
//     public static Action CreateBenchmark(Action action, string name, int times = 1000)
//     {
//         return () =>
//         {
//             var sw = new Stopwatch();
//             sw.Start();
//             for (int i = 0; i < times; i++)
//             {
//                 action();
//             }
//             sw.Stop();
//             Console.WriteLine($"Function {name}: {sw.Elapsed.TotalMilliseconds / times:0.000000} ms on average");
//         };
//     }
//
//     public static IEnumerable<Action> CreateBenchmarks()
//     {
//         return ImmutableList.Create(
//             CreateBenchmark(StringAdd, "String+="),
//             CreateBenchmark(StringBuilder, "StringBuilder"),
//             CreateBenchmark(StringJoin, "StringJoin"));
//     }
// }