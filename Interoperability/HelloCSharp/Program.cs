using System.Runtime.InteropServices;

namespace HelloCSharp;

public partial class Program
{
    [LibraryImport("HelloCpp")]
    private static partial void Hello();
    
    private static void Main()
    {
        Hello();
    }
}