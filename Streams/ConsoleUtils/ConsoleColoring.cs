namespace ConsoleUtils;

public readonly struct ConsoleColoring : IDisposable
{
    public ConsoleColor PreviousForeground { get; }
    public ConsoleColor PreviousBackground { get; }
    
    public ConsoleColoring()
    {
        PreviousForeground = Console.ForegroundColor;
        PreviousBackground = Console.BackgroundColor;
        Console.ResetColor();
    }

    public ConsoleColoring(ConsoleColor foreground, ConsoleColor background = ConsoleColor.Black)
    {
        PreviousForeground = Console.ForegroundColor;
        PreviousBackground = Console.BackgroundColor;
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
    }

    public void Dispose()
    {
        Console.BackgroundColor = PreviousBackground;
        Console.ForegroundColor = PreviousForeground;
    }

    public static IDisposable Change(ConsoleColor foreground, ConsoleColor background = ConsoleColor.Black)
    {
        ConsoleColor previousForeground = Console.ForegroundColor;
        ConsoleColor previousBackground = Console.BackgroundColor;
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        return new Disposable(() =>
        {
            Console.BackgroundColor = previousBackground;
            Console.ForegroundColor = previousForeground;
        });
    }
}