namespace SafeHandleCSharp;

class Program
{
    static void Main()
    {
        using var str = NativeString.CreateString();
        NativeString.PrintString(str);
    }
}