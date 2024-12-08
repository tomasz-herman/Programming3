using System.IO.Compression;

namespace ZipFiles;

class Program
{
    static void Main(string[] args)
    {
        Cleanup();
        ZipFile.CreateFromDirectory(".", "../output.zip");
        ZipFile.ExtractToDirectory("../output.zip", "../output");

        using ZipArchive zip = ZipFile.Open("../output.zip", ZipArchiveMode.Read);
        foreach (ZipArchiveEntry entry in zip.Entries)
            Console.WriteLine($"{entry.FullName,-32} size: {entry.Length}");
    }

    static void Cleanup()
    {
        try
        {
            File.Delete("../output.zip");
        }
        catch (Exception)
        {
            // ignored
        }

        try
        {
            Directory.Delete("../output", true);
        }
        catch (Exception)
        {
            // ignored
        }
    }
}