using System.Diagnostics;
using System.IO.Pipes;

namespace Pipes.Anonymous;

class Program
{
    private const int BufferSize = 256;

    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            ChildWork(args[0]);
        }
        else
        {
            ParentWork();
        }
    }

    static void ParentWork()
    {
        using var pipe = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);

        var startInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"{System.Reflection.Assembly.GetExecutingAssembly().Location} {pipe.GetClientHandleAsString()}",
        };

        using var childProcess = Process.Start(startInfo);
        if (childProcess == null)
        {
            Console.WriteLine("Failed to create child process");
            Environment.Exit(1);
        }
        Console.WriteLine("Child process started with PID: " + childProcess.Id);
        
        SendLorem(childProcess, pipe);
    }

    static void SendLorem(Process child, AnonymousPipeServerStream pipe)
    {
        using var fs = File.OpenRead("lorem.txt");
        byte[] buffer = new byte[BufferSize];
        int read;
        
        while ((read = fs.Read(buffer, 0, BufferSize)) > 0)
        {
            pipe.Write(buffer, 0, read);
        }
        
        pipe.Dispose();
        child.WaitForExit();
        Console.WriteLine("Child process exited.");
    }

    static void ChildWork(string pipeHandle)
    {
        using var pipe = new AnonymousPipeClientStream(PipeDirection.In, pipeHandle);

        using var fs = File.OpenWrite("lorem_rot13.txt");
        byte[] buffer = new byte[BufferSize];
        int read;
        while ((read = pipe.Read(buffer, 0, BufferSize)) > 0)
        {
            Console.WriteLine("Child: Applying Rot13 on received text");
            Rot13(buffer, read);
            fs.Write(buffer, 0, read);
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
        }
    }

    static void Rot13(byte[] buffer, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (buffer[i] > 'a' && buffer[i] < 'z')
            {
                buffer[i] += 13;
                if (buffer[i] > 'z') buffer[i] -= 26;
            }
            if (buffer[i] > 'A' && buffer[i] < 'Z')
            {
                buffer[i] += 13;
                if (buffer[i] > 'Z') buffer[i] -= 26;
            }
        }
    }
}