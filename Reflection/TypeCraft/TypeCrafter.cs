using System.Reflection;

namespace TypeCraft;

public static class TypeCrafter
{
    public static T TypeCraft<T>()
    {
        Type type = typeof(T);
        Console.WriteLine($"Constructing {type.FullName} type");
        PropertyInfo[] properties = type.GetProperties();
        ConstructorInfo? constructor = type.GetConstructor(Type.EmptyTypes);
        if (constructor == null)
        {
            throw new InvalidOperationException($"Type {type.FullName} has no parameterless constructor.");
        }

        T result = (T)constructor.Invoke(null);
        foreach (PropertyInfo property in properties)
        {
            Type propertyType = property.PropertyType;
            Type parsableType = typeof(IParsable<>);
            var parsable = propertyType.GetInterfaces()
                .Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == parsableType &&
                          t.GetGenericArguments()[0] == propertyType);
            if (propertyType == typeof(string))
            {
                string input = AskForInput(property.Name, propertyType.Name);
                property.SetValue(result, input);
            }
            else if (parsable)
            {
                string input = AskForInput(property.Name, propertyType.Name);
                MethodInfo? parseMethod = propertyType.GetMethod(
                    "Parse",
                    BindingFlags.Public | BindingFlags.Static,
                    binder: null,
                    types: [typeof(string), typeof(IFormatProvider)],
                    modifiers: null
                );
                if (parseMethod == null)
                {
                    throw new Exception($"{propertyType.FullName} does not have a static Parse method.");
                }

                object? parsed = parseMethod.Invoke(null, [input, null!]);
                property.SetValue(result, parsed);
            }
        }

        return result;
    }

    private static string AskForInput(string propertyName, string type)
    {
        Console.WriteLine($"Provide a variable {propertyName} of type {type}:");
        if (Console.ReadLine() is { } line)
        {
            return line;
        }

        throw new IOException("Line from the Console is not available");
    }
}