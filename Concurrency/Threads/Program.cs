namespace Threads;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.Name = "Main";
        CreatingThreads();
        ThreadSafety();
        ExceptionHandling();
        BackgroundThread();
    }

    private static void CreatingThreads()
    {
        Thread thread = new Thread(PrintA)
        {
            Name = "Worker"
        };
        thread.Start();

        PrintB();

        thread.Join();
        Console.WriteLine();
    }

    private static void PrintA()
    {
        Console.WriteLine(Thread.CurrentThread.Name + " write A:");
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(10));
            Console.Write('A');
        }
    }
    
    private static void PrintB()
    {
        Console.WriteLine(Thread.CurrentThread.Name + " write B:");
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(millisecondsTimeout: 10);
            Console.Write('B');
        }
    }

    private static void ThreadSafety()
    {
        Thread thread = new Thread(UnsafePrintOnce);
        thread.Start();
        UnsafePrintOnce();
        thread.Join();
    }

    private static bool _done = false;
    private static void UnsafePrintOnce()
    {
        if (_done) return;
        _done = true; // There is a slight chance Done will be printed twice
        Console.WriteLine("Done");
    }
    
    private static readonly object Locker = new();
    private static bool _safeDone = false;
    private static void SafePrintOnce()
    {
        lock (Locker)
        {
            if (_safeDone) return;
            _safeDone = true;
        }
        Console.WriteLine("Done Safely");
    }

    private static void ExceptionHandling()
    {
        new Thread(ThrowsException).Start();
    }

    private static void ThrowsException()
    {
        try
        {
            throw new Exception("Unhandled exception");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message} caught");
        }
    }

    private static void BackgroundThread()
    {
        Thread worker = new Thread ( () => Console.ReadLine() )
        {
            Name = "BackgroundWorker",
            IsBackground = true
        };
        worker.Start();
    }
}