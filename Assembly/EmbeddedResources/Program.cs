using System.Globalization;
using System.Reflection;
using System.Resources;

namespace EmbeddedResources;

class Program
{
    static void Main()
    {
        Assembly? a = Assembly.GetEntryAssembly();
        using (Stream? s = a?.GetManifestResourceStream("EmbeddedResources.lorem.txt"))
        {
            if (s == null) throw new MissingManifestResourceException("Resource not found");
            StreamReader sr = new StreamReader(s);
            Console.WriteLine(sr.ReadLine());
        }
        
        ResourceManager rm = new ResourceManager("EmbeddedResources.Resources", typeof(Program).Assembly);
        string? welcome = rm.GetString("Welcome", CultureInfo.CreateSpecificCulture("pl"));
        string? demo = rm.GetString("Demo");
        Console.WriteLine(welcome);
        Console.WriteLine(demo);
    }
}