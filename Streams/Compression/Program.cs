using System.IO.Compression;

namespace Compression;

class Program
{
    static void Main(string[] args)
    {
        Compress("lorem.txt", "lorem.txt.compressed");
        Decompress("lorem.txt.compressed", "decompressed_lorem.txt");
    }

    static void Compress(string input, string output)
    {
        using var fsIn = File.OpenRead(input);
        using var fsOut = File.Create(output);
        using var ds = new GZipStream(fsOut, CompressionMode.Compress);
        
        byte[] buffer = new byte[4096];
        int read;

        while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
        {
            ds.Write(buffer, 0, read);
        }
    }

    static void Decompress(string input, string output)
    {
        using var fsIn = File.OpenRead(input);
        using var ds = new GZipStream(fsIn, CompressionMode.Decompress);
        using var fsOut = File.Create(output);

        byte[] buffer = new byte[4096];
        int read;

        while ((read = ds.Read(buffer, 0, buffer.Length)) > 0)
        {
            fsOut.Write(buffer, 0, read);
        }
    }
}