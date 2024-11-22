#define REFLECTION

using System.Reflection;

namespace Events;

class Program
{
    static void Main()
    {
        var alpha = new Server("192.168.1.10", "Alpha", Status.Running, 25);
        Console.WriteLine(alpha);
#if !REFLECTION
        alpha.PropertyChanged += (sender, e) =>
        {
            if (sender is not Server server) return;

            var value = e.PropertyName switch
            {
                nameof(Server.Load) => $"{server.Load}",
                nameof(Server.Status) => $"{server.Status}",
                nameof(Server.Name) => $"{server.Name}",
                _ => "Unknown"
            };

            Console.WriteLine($"{server}: {e.PropertyName} => {value}");
        };
#else
        alpha.PropertyChanged += (sender, e) =>
        {
            if (sender is not Server server) return;
            if (e.PropertyName is null) return;

            Type serverType = server.GetType();
            PropertyInfo? propertyInfo = serverType.GetProperty(e.PropertyName);
            object value = propertyInfo?.GetValue(server) ?? "Unknown";

            Console.WriteLine($"{server}: {e.PropertyName} => {value}");
        };
#endif
        alpha.Status = Status.Stopped;
        alpha.Load = 0.0;
        alpha.Name = "Beta";
    }
}