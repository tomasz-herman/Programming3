namespace Tasks;

class Program
{
    static void Main(string[] args)
    {
        CreateTask();
        ReturningValueFromTask();
        ExceptionHandling();
        TaskContinuations();
        LongRunningTasks();
    }

    private static void CreateTask()
    {
        Task task = Task.Run(() =>
        {
            Task.Delay(1000).Wait();
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine("Hello from the thread pool");
        });

        Console.WriteLine($"Is completed: {task.IsCompleted}");
        task.Wait(); // blocks until task finishes
        Console.WriteLine($"Is completed: {task.IsCompleted}");
    }

    private static void ReturningValueFromTask()
    {
        Task<int> task1 = Task.Run(() => CountPrimes(1000000, 1000000));
        Task<int> task2 = Task.Run(() => CountPrimes(2 * 1000000, 1000000));
        Console.WriteLine("Started two tasks counting primes");
        Console.WriteLine($"Primes(1000000, 2000000): {task1.Result}");
        Console.WriteLine($"Primes(2000000, 3000000): {task2.Result}");
    }

    private static int CountPrimes(int from, int count)
    {
        return Enumerable.Range(from, count).Count(n =>
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(n));
          
            for (int i = 3; i <= boundary; i += 2)
                if (n % i == 0)
                    return false;
    
            return true; 
        });
    }
    
    private static void ExceptionHandling()
    {
        Task task = Task.Run(ThrowsException);

        try
        {
            task.Wait();
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"Handled: {e.InnerException?.Message}");
        }
    }

    private static void ThrowsException()
    {
        throw new Exception("Unhandled exception");
    }
    
    private static void TaskContinuations()
    {
        Task<int> t = Task.Run(() => CountPrimes(1000000, 1000000));
        Task continuation = t.ContinueWith((Task<int> task) =>
        {
            Console.WriteLine($"Primes(1000000, 2000000): {task.Result}");
        });

        continuation.Wait();
    }

    private static void LongRunningTasks()
    {
        Task<int> t = Task.Factory.StartNew(() =>
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}");
            return CountPrimes(2, 1_000_000_000);
        }, TaskCreationOptions.LongRunning);
        
        t.Wait();
    }
}