namespace ConsoleUtils;

public class Program
{
    public static void Main()
    {
        using (var red = new ConsoleColoring(ConsoleColor.Red))
        {
            Console.WriteLine("Very important message (in red)");
            using var green = new ConsoleColoring(ConsoleColor.Green);
            Console.WriteLine("An information (in green)");
            using (var blue = new ConsoleColoring(ConsoleColor.Blue, ConsoleColor.White))
            {
                Console.WriteLine("An information (in blue, on white)");
            }
            using (var cyan = ConsoleColoring.Change(ConsoleColor.Cyan))
            {
                Console.WriteLine("An information (in cyan)");
            }
            Console.WriteLine("An information (in green again)");
        }

        Console.WriteLine("Message in default color");
    }
}