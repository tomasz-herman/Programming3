namespace Enums;

[Flags]
public enum Anchor
{
    None = 0,
    Left = 1,
    Right = 1 << 1,
    Top = 1 << 2,
    Bottom = 1 << 3,
    LeftRight = Left | Right,
    TopBottom = Top | Bottom,
    LeftTop = Left | Top,
    LeftBottom = Left | Bottom,
    RightTop = Right | Top,
    RightBottom = Right | Bottom,
    All = Left | Right | Top | Bottom
}