using System.Runtime.InteropServices;

namespace StructsCSharp;

public partial class Program
{
    [LibraryImport("StructsCpp")]
    private static partial Color Add(Color a, Color b); 
    
    [LibraryImport("StructsCpp")]
    private static partial void Darken(ref Color b);
    
    [LibraryImport("StructsCpp")]
    private static partial void PrintHex(Color a);

    static void Main(string[] args)
    {
        Color color = new Color { Rgba = 0xffff00ff };
        PrintHex(color);
        Console.WriteLine(color);
        
        Darken(ref color);
        PrintHex(color);
        Console.WriteLine(color);
        
        color = Add(color, new Color{ Rgba=0xff00ff00 });
        PrintHex(color);
        Console.WriteLine(color);
    }
}