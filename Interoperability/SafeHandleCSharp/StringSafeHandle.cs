using System.Runtime.InteropServices;

namespace SafeHandleCSharp;

public class StringSafeHandle : SafeHandle
{
    public StringSafeHandle() : base(IntPtr.Zero, true) {}

    protected override bool ReleaseHandle()
    {
        NativeString.DestroyString(handle);
        handle = IntPtr.Zero;
        return true;
    }

    public override bool IsInvalid => handle == IntPtr.Zero;
}