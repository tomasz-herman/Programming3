using System.Reflection;
using System.Runtime.Loader;
using Plugin.Common;

namespace Plugin.Host;

class Program
{
    static void Main()
    {
        string hello = "Hello, World!";
        Console.WriteLine(ApplyPluginOperation(hello, "Plugins/Plugin.Rot13.dll"));
        Console.WriteLine(ApplyPluginOperation(hello, "Plugins/Plugin.Reverse.dll"));
    }

    private static string? ApplyPluginOperation(string input, string pluginPath)
    {
        PluginLoadContext context = new PluginLoadContext(pluginPath);
        try
        {
            Assembly assembly = context.LoadFromAssemblyPath(Path.GetFullPath(pluginPath));
            Type pluginType = assembly
                .ExportedTypes
                .Single(t => typeof(ITextPlugin).IsAssignableFrom(t));
            var plugin = Activator.CreateInstance(pluginType) as ITextPlugin;
            return plugin?.ApplyOperation(input);
        }
        finally
        {
            if (context.IsCollectible) context.Unload();
        }
    }
}