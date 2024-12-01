namespace Logger;

class Program
{
    static void Main(string[] args)
    {
        using var logger = new Logger("test.log");
        logger.Log("Hello World!");
        logger.Log("This logger will call Dispose");
        logger.Log("method automatically at the end of the scope.");
    }
}