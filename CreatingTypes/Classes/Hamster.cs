namespace Classes;

public partial class Hamster
{
    public string Name { get; set; }
    public int Level { get; set; }
    
    partial void Foo();
    public partial int Bar();
}