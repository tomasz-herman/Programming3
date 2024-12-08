using System.IO.Pipes;

namespace Pipes.Server;

class Program
{
    private const int BufferSize = 1024;
    static void Main()
    {
        using var pipe = new NamedPipeServerStream("p3_pipe");
        pipe.WaitForConnection();
        
        using var fs = File.OpenRead("lorem.txt");
        byte[] buffer = new byte[BufferSize];
        int read;
        while ((read = fs.Read(buffer, 0, BufferSize)) > 0)
        {
            pipe.Write(buffer, 0, read);
        }
    }
}