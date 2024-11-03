using System.Collections;

namespace Collections;

class Program
{
    static void Main(string[] args)
    {
        // Initialize a BitArray with 4 bits
        BitArray bits = new BitArray(4)
        {
            [0] = true, // Set the first bit to 1
            [1] = false, // Set the second bit to 0
            [2] = true, // Set the third bit to 1
            [3] = false // Set the fourth bit to 0
        };

        Console.WriteLine("BitArray values:");
        for (int i = 0; i < bits.Count; i++)
        {
            Console.WriteLine($"Bit {i}: {bits[i]}");
        }

        // Suppose we want to toggle all the bits (perform a NOT operation)
        bits.Not();

        Console.WriteLine("\nAfter NOT operation:");
        for (int i = 0; i < bits.Count; i++)
        {
            Console.WriteLine($"Bit {i}: {bits[i]}");
        }

        // Example of bitwise AND between two BitArrays
        BitArray bits2 = new BitArray(new[] { true, false, true, true });

        bits.And(bits2);

        Console.WriteLine("\nAfter AND operation with another BitArray { true, false, true, true }:");
        for (int i = 0; i < bits.Count; i++)
        {
            Console.WriteLine($"Bit {i}: {bits[i]}");
        }
    }
}