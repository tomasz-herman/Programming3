using System.IO.Pipes;

namespace Pipes.Client;

class Program
{
    private const int BufferSize = 1024;
    static void Main(string[] args)
    {
        using var pipe = new NamedPipeClientStream("p3_pipe");
        pipe.Connect();
        
        using var fs = File.OpenWrite("lorem.txt");
        byte[] buffer = new byte[BufferSize];
        int read;
        while ((read = pipe.Read(buffer, 0, BufferSize)) > 0)
        {
            fs.Write(buffer, 0, read);
        }
    }
}