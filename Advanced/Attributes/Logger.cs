using System.Runtime.CompilerServices;

namespace Attributes;

public static class Logger
{
    public static void Log(string message, 
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        Console.WriteLine($"[{memberName}] {sourceFilePath}:{sourceLineNumber}: {message}");
    }
}