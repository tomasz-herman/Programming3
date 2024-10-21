namespace Interfaces;

public interface ILogger
{
    public const string DefaultFile = "default.log";
    public static string LogPrefix { get; set; } = "Log: ";

    void Message(string message)
    {
        Console.WriteLine($"{LogPrefix} {message}");
    }
}

public class Logger : ILogger
{
    public void Message(string message)
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} {message}");
    }
}