namespace Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] names = ["Tom", "Dick", "Harry", "Mary", "Jay"];
        
        IEnumerable<string> filteredNames = names
            .Where(n => n.Length >= 4);
        foreach (string name in filteredNames) 
            Console.WriteLine(name);

        Console.WriteLine();
        
        IEnumerable<string> query = names
            .Where(n => n.Contains("a"))
            .OrderBy(n => n.Length)
            .Select(n => n.ToUpper());
        // Query is not executed, unless enumerated:
        foreach (var name in query)
        {
            Console.WriteLine(name);
        }
    }
}