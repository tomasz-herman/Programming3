using System.Runtime.InteropServices;

namespace StructsCSharp;

[StructLayout(LayoutKind.Explicit)]
public struct Color
{
    [FieldOffset(0)]
    public byte R;
    [FieldOffset(1)]
    public byte G;
    [FieldOffset(2)]
    public byte B;
    [FieldOffset(3)]
    public byte A;
    [FieldOffset(0)]
    public uint Rgba;

    public override string ToString()
    {
        return $"Red = {R}, Green = {G}, Blue = {B}, Alpha = {A}";
    }
}