using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Introduction;

public static class Program
{
    public static void Main()
    {
        QueryingMembers();
        QueryingWithTypeInfo();
        DynamicallyInvokingMember();
        MethodParameters();
        MethodInfoToDelegate();
        QueryingPrivateMembers();
        ReflectingAssemblies();
    }

    public static void QueryingMembers()
    {
        PrintCurrentMethodName();
        MemberInfo[] members = typeof(Person).GetMembers();
        foreach (MemberInfo member in members)
        {
            Console.WriteLine($"{member.MemberType,12}: {member}");
        }
    }
    
    public static void QueryingWithTypeInfo()
    {
        PrintCurrentMethodName();
        IEnumerable<MemberInfo> members = typeof(Person).GetTypeInfo().DeclaredMembers;
        foreach (MemberInfo member in members)
        {
            Console.WriteLine($"{member.MemberType,12}: {member}");
        }
    }

    public static void DynamicallyInvokingMember()
    {
        PrintCurrentMethodName();
        Person person = new Person("John", "Doe", 19);
        MethodInfo? method = typeof(Person).GetMethod(nameof(Person.IsAdult));
        if (method is null)
        {
            Console.WriteLine($"Method {nameof(Person.IsAdult)} not found");
        }
        else
        {
            bool? isAdult = method.Invoke(person, new object?[] { }) as bool?;
            Console.WriteLine($"Is Adult: {isAdult}");
        }
    }

    public static void MethodParameters()
    {
        PrintCurrentMethodName();
        ConstructorInfo? constructor = typeof(Person)
            .GetConstructor([typeof(string), typeof(string), typeof(int)]);
        Person? person = constructor?.Invoke(["John", "Doe", 42]) as Person;
        Console.WriteLine($"Name: {person?.FullName}, Age: {person?.Age}");
    }
    
    public static void MethodInfoToDelegate()
    {
        PrintCurrentMethodName();
        Person person = new Person("John", "Doe", 19);
        MethodInfo? method = typeof(Person).GetMethod(nameof(Person.IsAdult));
        if (method is not null)
        {
            int times = 1_000_000;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < times; i++)
            {
                method.Invoke(person, null);
            }
            sw.Stop();
            Console.WriteLine($"Invoke x{times}: {sw.ElapsedMilliseconds}ms");
            sw.Restart();
            // Binding to a delegate:
            Func<bool> isAdult = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), person, method);
            for (int i = 0; i < times; i++)
            {
                isAdult();
            }
            sw.Stop();
            Console.WriteLine($"Delegate x{times}: {sw.ElapsedMilliseconds}ms");
        }
    }
    
    public static void QueryingPrivateMembers()
    {
        PrintCurrentMethodName();
        MemberInfo[] members = typeof(string).GetMembers(
            BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (MemberInfo member in members)
        {
            Console.WriteLine($"{member.MemberType,12}: {member}");
        }
    }
    
    public static void ReflectingAssemblies()
    {
        PrintCurrentMethodName();
        Assembly? assembly;
        assembly = Assembly.GetEntryAssembly();
        assembly = Assembly.GetCallingAssembly();
        assembly = Assembly.GetExecutingAssembly();
        assembly = Assembly.GetAssembly(typeof(Person));
        if (assembly is null) return; 
        foreach (var type in assembly.GetTypes())
        {
            Console.WriteLine(type.FullName);
        }
    }

    private static void PrintCurrentMethodName([CallerMemberName] string caller = "")
    {
        Console.WriteLine("***************************************");
        Console.WriteLine($"* Method: {caller,27} *");
        Console.WriteLine("***************************************");
    }
}