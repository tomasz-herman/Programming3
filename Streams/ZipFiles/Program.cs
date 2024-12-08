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
        if (File.Exists("../output.zip"))
            File.Delete("../output.zip");
        if (Directory.Exists("../output"))
            Directory.Delete("../output", true);
    }
}