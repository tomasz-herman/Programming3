using System.Runtime.InteropServices;

namespace SafeHandleCSharp;

public static partial class NativeString
{
    [LibraryImport("SafeHandleCpp")]
    public static partial StringSafeHandle CreateString();

    [LibraryImport("SafeHandleCpp")]
    public static partial void PrintString(StringSafeHandle str);

    [LibraryImport("SafeHandleCpp")]
    public static partial void DestroyString(IntPtr str);
}