namespace Syntax;

class Program
{
    static void Main(string[] args)
    {
        // Local variables in camelCase
        var john = new Person("John", "Doe", 25);
        var jane = new Person("Jane", "Smith", 16);

        john.DisplayPersonInfo();
        john.DisplayAdultStatus();

        Console.WriteLine("--------------------------------");

        jane.DisplayPersonInfo();
        jane.DisplayAdultStatus();
    }
}