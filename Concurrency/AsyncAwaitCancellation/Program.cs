namespace AsyncAwaitCancellation;

class Program
{
    private static async Task Main()
    {
        var cancellationSource = new CancellationTokenSource(5000);
        try
        {
            List<int> primes = await GetPrimesAsync(2, cancellationSource.Token);
            Console.WriteLine($"Number of primes: {primes.Count}");
            Console.WriteLine($"Last prime: {primes[^1]}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Canceled");
        }
    }
    
    static async Task<List<int>> GetPrimesAsync(int start, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            List<int> primes = [];

            for (int i = start; i < int.MaxValue; i++)
            {
                if (token.IsCancellationRequested) break;
                // token.ThrowIfCancellationRequested();
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }, token);
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}