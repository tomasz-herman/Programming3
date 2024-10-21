namespace Interfaces;

public interface IDescriptable
{
    static abstract string Description { get; }
    static virtual string Category => null;
}

public class Cat : IDescriptable
{
    public static string Description => "It's a cat";
    public static string Category => "Mammal"; // optional
}