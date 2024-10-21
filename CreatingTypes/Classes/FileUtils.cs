namespace Classes;

public static class FileUtils
{
    public static long GetFileSize(string path)
    {
        FileInfo info = new FileInfo(path);
        if (!info.Exists)
        {
            return 0;
        }
        else
        {
            return info.Length;
        }
    }
    
    public static string GetCurrentDirectory()
    {
        return Environment.CurrentDirectory;
    }
}