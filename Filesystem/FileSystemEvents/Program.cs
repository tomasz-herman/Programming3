namespace FileSystemEvents;

class Program
{
    static void Main(string[] args)
    {
        Watch(".", "*.*", false);
    }
    
    static void Watch(string path, string filter, bool includeSubDirs)
    {
        using var watcher = new FileSystemWatcher(path, filter);
        watcher.Created += OnCreated;
        watcher.Changed += OnChanged;
        watcher.Deleted += OnDeleted;
        watcher.Renamed += OnRenamed;
        watcher.Error += OnError;
        watcher.IncludeSubdirectories = includeSubDirs;
        watcher.EnableRaisingEvents = true;
        Console.WriteLine("Listening for events - press <enter> to end");
        Console.ReadLine();
    }
    
    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType != WatcherChangeTypes.Changed)
        {
            return;
        }
        Console.WriteLine($"Changed: {e.FullPath}");
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        string value = $"Created: {e.FullPath}";
        Console.WriteLine(value);
    }

    private static void OnDeleted(object sender, FileSystemEventArgs e) =>
        Console.WriteLine($"Deleted: {e.FullPath}");

    private static void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"Renamed:");
        Console.WriteLine($"    Old: {e.OldFullPath}");
        Console.WriteLine($"    New: {e.FullPath}");
    }

    private static void OnError(object sender, ErrorEventArgs e) =>
        Console.WriteLine(e.GetException());
}