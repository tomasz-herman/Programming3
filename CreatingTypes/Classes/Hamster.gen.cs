namespace Classes;

public partial class Hamster
{
    public void LevelUp()
    {
        Level++;
    }

    partial void Foo() // optional
    {
        Console.WriteLine("Foo from generated class");
    }
    
    public partial int Bar()
    {
        Foo();
        Console.WriteLine("Bar from generated class");
        return Level;
    }
}