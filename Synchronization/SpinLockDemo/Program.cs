using System.Diagnostics;

namespace SpinLockDemo;

class Program
{
    static async Task Main(string[] args)
    {
        int counter = 0, times = 1_000_000;
        SpinLock spinLock = new SpinLock();
        
        var sw = Stopwatch.StartNew();

        var increment = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
            {
                bool lockTaken = false;
                try
                {
                    spinLock.Enter(ref lockTaken);
                    counter++;
                }
                finally
                {
                    if (lockTaken) spinLock.Exit();
                }
            }
        });

        var decrement = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
            {
                bool lockTaken = false;
                try
                {
                    spinLock.Enter(ref lockTaken);
                    counter--;
                }
                finally
                {
                    if (lockTaken) spinLock.Exit();
                }
            }
        });

        await Task.WhenAll(increment, decrement);

        sw.Stop();

        Console.WriteLine($"Counter Value: {counter}");
        Console.WriteLine($"Time: {sw.Elapsed}");
    }
}