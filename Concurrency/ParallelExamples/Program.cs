namespace ParallelExamples;

class Program
{
    static void Main()
    {
        ParallelInvoke();
        ParallelFor();
        ParallelForeach();
        ParallelBreak();
    }

    private static void ParallelInvoke()
    {
        Parallel.Invoke(
            () => DownloadFile("https://pages.mini.pw.edu.pl/~hermant/wp-content/uploads/2024/10/Tomek-1152x1536.jpg", "hermant.jpg"),
            () => DownloadFile("https://pages.mini.pw.edu.pl/~aszklarp/images/me.jpg", "aszklarp.jpg"),
            () => DownloadFile("https://cadcam.mini.pw.edu.pl/static/media/kadra8.7b107dbb.jpg", "sobotkap.jpg"));
    }
    
    private static void DownloadFile(string url, string outputPath)
    {
        using HttpClient httpClient = new HttpClient();
        try
        {
            var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            File.WriteAllBytes(outputPath, content);

            Console.WriteLine($"{outputPath} downloaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading {url}: {ex.Message}");
        }
    }
    
    private static void ParallelFor()
    {
        int from = 0, to = 100;
        Console.WriteLine("For loop");
        for (int i = from; i < to; i++)
        {
            Console.WriteLine($"Is {i} prime: {IsPrime(i)}");
        }

        Console.WriteLine("Parallel.For");
        Parallel.For(from, to, i =>
        {
            Console.WriteLine($"Is {i} prime: {IsPrime(i)}");
        });
    }
    
    private static void ParallelBreak()
    {
        Console.WriteLine("Parallel.For with Break");
        var result = Parallel.For(10000, 10010, (i, loopState) =>
        {
            if (IsPrime(i))
            {
                loopState.Break();
            }
        });
        if (!result.IsCompleted)
        {
            Console.WriteLine($"There is a prime: {result.LowestBreakIteration}");
        }
        else
        {
            Console.WriteLine("There are no primes");
        }
    }
    
    private static bool IsPrime(int number)
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

    private static void ParallelForeach()
    {
        List<(string, string)> urls =
        [
            ("https://pages.mini.pw.edu.pl/~hermant/wp-content/uploads/2024/10/Tomek-1152x1536.jpg", "hermant.jpg"),
            ("https://pages.mini.pw.edu.pl/~aszklarp/images/me.jpg", "aszklarp.jpg"),
            ("https://pages.mini.pw.edu.pl/~rafalkoj/templates/mini/images/photo.jpg", "rafalkoj.jpg"),
            ("https://pages.mini.pw.edu.pl/~kaczmarskik/krzysztof.jpg", "kaczmarskik.jpg"),
            ("https://cadcam.mini.pw.edu.pl/static/media/kadra8.7b107dbb.jpg", "sobotkap.jpg")
        ];

        Parallel.ForEach(urls, ((string url, string output) tuple) =>
        {
            DownloadFile(tuple.url, tuple.output);
        });
    }
}