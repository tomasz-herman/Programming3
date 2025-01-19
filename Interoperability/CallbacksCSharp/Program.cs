using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CallbacksCSharp;

public partial class Program
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Callback(int value);
    
    [LibraryImport("CallbacksCpp")]
    private static partial void Count(int from , int to, Callback callback);
    
    [LibraryImport("CallbacksCpp")]
    private static unsafe partial void Count(int from , int to, delegate* unmanaged[Cdecl]<int, void> callback);
    
    static unsafe void Main(string[] args)
    {
        Count(1, 101, i =>
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        });
        
        Count(1, 101, &FizzBuzz);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof (CallConvCdecl)])]
    static void FizzBuzz(int i)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (i % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (i % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
}