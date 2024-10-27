namespace Generics;

public static class MathUtils
{
    public static T Max<T>(T value, params T[] values) where T : IComparable<T>
    {
        var max = value;
        foreach (var t in values)
        {
            if (max.CompareTo(t) < 0)
            {
                max = t;
            }
        }
        return max;
    }
}
