using System.Runtime.InteropServices;

namespace Drives;

class Program
{
    static void Main(string[] args)
    {
        string drive;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || 
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ||  
            RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
        {
            drive = "/";
        }
        else
        {
            drive = "C";
        }
        DriveInfo c = new DriveInfo(drive);
        long totalSize = c.TotalSize;
        long freeBytes = c.TotalFreeSpace;
        long availableBytes = c.AvailableFreeSpace;
        Console.WriteLine($"Total size: {totalSize}");
        Console.WriteLine($"Free size: {freeBytes}");
        Console.WriteLine($"Available size: {availableBytes}");

        foreach (DriveInfo d in DriveInfo.GetDrives())
        {
            Console.WriteLine(d.Name);
        }
    }
}