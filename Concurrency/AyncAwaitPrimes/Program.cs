namespace AyncAwaitPrimes;

class Program
{
    private static async Task Main()
    {
        for (int i = 0; i < 10; i++)
        {
            int from = 1_000_000 * i;
            int to = 1_000_000 * (i + 1);
            var primes = CountPrimesAsync(from, to);
            Console.WriteLine($"Primes from from {from} to {to}: {await primes}");
        }
    }

    static async Task<int> CountPrimesAsync(int start, int end)
    {
        return await Task.Run(() =>
        {
            int count = 0;

            for (int i = start; i < end; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
            }

            return count;
        });
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