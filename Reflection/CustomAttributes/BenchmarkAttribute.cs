namespace CustomAttributes;

[AttributeUsage(AttributeTargets.Method)]
public class BenchmarkAttribute : Attribute
{
    public int Repetitions { get; }

    public BenchmarkAttribute(int repetitions = 10)
    {
        Repetitions = repetitions;
    }
}