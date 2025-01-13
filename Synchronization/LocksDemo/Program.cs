using System.Diagnostics;

namespace LocksDemo;

class Program
{
    private static async Task Main()
    {
        int counter = 0, times = 1_000_000;
        object locker = new object();
                
        var sw = Stopwatch.StartNew();
        var increment = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
                lock(locker) counter++;
        });
        var decrement = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
                lock(locker) counter--;
        });
        
        await Task.WhenAll(increment, decrement);

        sw.Stop();

        Console.WriteLine($"Counter Value: {counter}");
        Console.WriteLine($"Time: {sw.Elapsed}");
    }
}