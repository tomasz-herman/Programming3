namespace Inheritance;

class Program
{
    static void Main(string[] args)
    {
        Base b = new Derived();
        Console.WriteLine("Base -, Derived - (warning, it hides method):");
        b.Method1();
        Console.WriteLine("Base virtual, Derived - (warning, it hides method):");
        b.Method2();
        Console.WriteLine("Base abstract, Derived - (error, abstract method needs implicit override)");
        // b.Method3();
        Console.WriteLine("Base -, Derived override (error, can override only abstract or virtual)");
        // b.Method4();
        Console.WriteLine("Base virtual, Derived override:");
        b.Method5();
        Console.WriteLine("Base abstract, Derived override:");
        b.Method6();
        Console.WriteLine("Base -, Derived new:");
        b.Method7();
        Console.WriteLine("Base virtual, Derived new:");
        b.Method8();
        Console.WriteLine("Base abstract, Derived new (error, needs to override abstract method)");
        // b.Method9();
    }
}

public abstract class Base
{
    public void Method1()
    {
        Console.WriteLine("Base Method1");
    }
    
    public virtual void Method2()
    {
        Console.WriteLine("Base Method2");
    }

    public abstract void Method3();
    
    public void Method4()
    {
        Console.WriteLine("Base Method4");
    }
    
    public virtual void Method5()
    {
        Console.WriteLine("Base Method5");
    }

    public abstract void Method6();
    
    public void Method7()
    {
        Console.WriteLine("Base Method7");
    }
    
    public virtual void Method8()
    {
        Console.WriteLine("Base Method8");
    }

    public abstract void Method9();
}

class Derived : Base
{
    public void Method1() // warning
    {
        Console.WriteLine("Derived Method1");
    }

    public void Method2() // warning
    {
        Console.WriteLine("Derived Method2");
    }

    public override void Method3()
    // public void Method3() // abstract method needs implicit override
    {
        Console.WriteLine("Derived Method3");
    }
    
    public new void Method4()
    // public override void Method4() // can override only abstract or virtual
    {
        Console.WriteLine("Derived Method4");
    }

    public override void Method5()
    {
        Console.WriteLine("Derived Method5");
    }

    public override void Method6()
    {
        Console.WriteLine("Derived Method6");
    }

    public new void Method7()
    {
        Console.WriteLine("Derived Method7");
    }

    public new void Method8()
    {
        Console.WriteLine("Derived Method8");
    }

    public override void Method9()
    // public new void Method9() // needs to override abstract method
    {
        Console.WriteLine("Derived Method9");
    }
}