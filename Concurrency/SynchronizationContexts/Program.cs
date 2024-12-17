namespace SynchronizationContexts;

class Program
{
    private static SynchronizationContext? _context;

    static void Main(string[] args)
    {
        _context = new MySynchronizationContext();
        new Thread(() =>
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} thread started");
            _context?.Post(_ =>
            {
                Console.WriteLine($"Message from: {Thread.CurrentThread.Name}");
            }, null);
        }){Name = "Worker"}.Start();
    }
}