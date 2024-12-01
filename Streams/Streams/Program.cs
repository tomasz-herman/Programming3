namespace Streams;

class Program
{
    static void Main()
    {
        // Create a file called test.txt in the current directory:
        using Stream stream = new FileStream("test.txt", FileMode.Create);
        Console.WriteLine($"Can read: {stream.CanRead}");
        Console.WriteLine($"Can write: {stream.CanWrite}");
        Console.WriteLine($"Can Seek: {stream.CanSeek}");

        stream.WriteByte(101);
        stream.WriteByte(102);
        byte[] block = [1, 2, 3, 4, 5];
        stream.Write (block, 0, block.Length);

        Console.WriteLine($"Stream length: {stream.Length}");
        Console.WriteLine($"Stream position: {stream.Position}");
        stream.Position = 0;

        Console.WriteLine($"First byte: {stream.ReadByte()}");
        Console.WriteLine($"Second byte: {stream.ReadByte()}");
        Console.WriteLine($"Reading {block.Length} bytes, twice:");
        Console.WriteLine($"Read: {stream.Read(block, 0, block.Length)} bytes");
        Console.WriteLine($"Read {stream.Read(block, 0, block.Length)} bytes");
    }
}