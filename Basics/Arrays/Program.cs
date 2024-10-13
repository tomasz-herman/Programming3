using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Arrays;

public static class Program
{
    private static void Main()
    {
        SingleDimensionalArrays();
        RectangularArrays();
        JaggedArrays();
        ValueAndReferenceTypesArrays();
        IndicesAndRanges();
    }

    private static void SingleDimensionalArrays()
    {
        PrintCurrentMethodName();
        int[] primes = new int[] {2, 3, 5, 7, 11};
        char[] vowels = {'a', 'e', 'i', 'o', 'u'};
        uint[] even = [0, 2, 4, 6, 8]; // C# 12
        float[] data = new float[10];
        Array array = primes;

        Console.WriteLine($"Primes array length: {primes.Length}");
        for (int i = 0; i < primes.Length; i++)
        {
            Console.WriteLine(primes[i]);
        }
    }

    private static void RectangularArrays()
    {
        PrintCurrentMethodName();
        float[,] matrix = new float[,]
        {
            { 1.0f, 0.0f, 0.0f },
            { 0.0f, 1.0f, 0.0f },
            { 0.0f, 0.0f, 1.0f }
        };
        float[,] matrix3x4 = new float[3, 4];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.WriteLine($"m[{i}, {j}] = {matrix[i, j]}");
            }
        }
    }

    private static void JaggedArrays()
    {
        PrintCurrentMethodName();
        float[][] matrix = new float[][]
        {
            new float[] { 1.0f, 0.0f, 0.0f },
            new float[] { 0.0f, 1.0f, 0.0f },
            new float[] { 0.0f, 0.0f, 1.0f }
        };
        float[][] matrix3x4 = new float[3][];
        for (int i = 0; i < matrix3x4.Length; i++)
        {
            matrix3x4[i] = new float[4];
        }
        float[][] matrix2x3 =
        [
            [1.0f, 0.0f, 2.0f],
            [0.0f, 1.0f, 3.0f]
        ];
        
        for (int i = 0; i < matrix.Length; i++)
        {
            var row = matrix[i];
            for (int j = 0; j < row.Length; j++)
            {
                Console.WriteLine($"m[{j}, {i}] = {row[j]}");
            }
        }
    }

    private static void ValueAndReferenceTypesArrays()
    {
        PrintCurrentMethodName();
        Point[] points = new Point[4];
        Person[] people = new Person[4];

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"points[{i}] = {points[i].X}, {points[i].Y}");
            Console.WriteLine($"people[{i}] = {people[i]}");
        }

        points[0].X = 10.5f; // OK
        // people[0].Name = "Anne"; // Runtime error, NullReference exception
    }
    private struct Point { public float X, Y; }
    private class Person { public string Name; public int Age; }

    private static void IndicesAndRanges()
    {
        PrintCurrentMethodName();
        int[] primes = new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37};
        int firstElem = primes[0], secondElem = primes[1];
        int lastElem = primes[^1], secondToLastElem = primes[^2];
        Index first = 0;
        Index last = ^1;
        firstElem = primes[first]; 
        lastElem = primes[last];
        
        int[] firstTwo = primes[..2]; // exclusive end
        int[] withoutFirst = primes[1..]; // inclusive start
        int[] withoutLast = primes[..^1];
        int[] withoutFirstAndLast = primes[1..^1];
        int[] all = primes[..];
        Range lastTwoRange = ^2..;
        int[] lastTwo = primes[lastTwoRange];
    }
        
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void PrintCurrentMethodName()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);

        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {sf!.GetMethod()!.Name,27} *");
        Console.WriteLine("***************************************");
    }
}