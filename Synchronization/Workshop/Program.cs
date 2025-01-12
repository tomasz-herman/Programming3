namespace Workshop;

class Program
{
    static async Task Main(string[] args)
    {
        CancellationTokenSource source = new CancellationTokenSource();
        Workshop workshop = new Workshop();
        Task simulation = workshop.Start(source.Token);
        
        Console.WriteLine("Press any key to cancel...");
        Console.ReadKey();
        await source.CancelAsync();
        await simulation;
    }
}