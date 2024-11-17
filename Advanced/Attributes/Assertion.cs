using System.Runtime.CompilerServices;

namespace Attributes;

public static class Assertion
{
    public static void Assert(bool condition, 
        [CallerArgumentExpression(nameof(condition))]string? message = null)
    {
        if (!condition)
        {
            Console.Error.WriteLine($"Assertion failed: {message}");
        }
    }
}
