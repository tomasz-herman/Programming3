namespace Generics;

public class GenericMethods
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    
    public static (T1, T2)[] Zip<T1, T2>(T1[] first, T2[] second)
    {
        if (first.Length != second.Length)
        {
            throw new ArgumentException("Both arrays must have the same length");
        }
        
        var result = new (T1, T2)[first.Length];
        for (int i = 0; i < first.Length; i++)
        {
            result[i] = (first[i], second[i]);
        }

        return result;
    }
    
    public static (T1[], T2[]) Unzip<T1, T2>((T1 first, T2 second)[] array)
    {
        var r1 = new T1[array.Length];
        var r2 = new T2[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            r1[i] = array[i].first;
            r2[i] = array[i].second;
        }

        return (r1, r2);
    }
}