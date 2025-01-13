using System.Diagnostics;

namespace MutexDemo;

class Program
{
    private static async Task Main()
    {
        int counter = 0, times = 1_000_000;
        using var mutex = new Mutex();
                
        var sw = Stopwatch.StartNew();
        var increment = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
            {
                mutex.WaitOne(); 
                counter++; 
                mutex.ReleaseMutex();
            }
        });
        var decrement = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
            {
                mutex.WaitOne(); 
                counter--; 
                mutex.ReleaseMutex();
            }
        });
        
        await Task.WhenAll(increment, decrement);

        sw.Stop();

        Console.WriteLine($"Counter Value: {counter}");
        Console.WriteLine($"Time: {sw.Elapsed}");
    }
}