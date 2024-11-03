namespace ExtensionMethods;

public static class MyExtensions
{
    public static int WordCount(this string str)
    {
        return str.Split(' ', 
            StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
    {
        foreach (var item in sequence)
        {
            if(predicate(item))
                yield return item;
        }
    }
}