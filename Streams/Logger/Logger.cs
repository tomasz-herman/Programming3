using System.Runtime.CompilerServices;

namespace Logger;

public class Logger : IDisposable
{
    private readonly StreamWriter _sw;

    public Logger(string path)
    {
        _sw = new StreamWriter(path, append: true);
    }

    public void Log(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
        _sw.WriteLine($"{DateTime.Now} [{memberName}] {sourceFilePath}({sourceLineNumber}): {message}");
    }

    public void Dispose()
    {
        Console.WriteLine("Disposing logger...");
        _sw.Dispose();
    }
}