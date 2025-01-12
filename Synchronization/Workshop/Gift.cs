namespace Workshop;

public class Gift
{
    private Status _status;
    private readonly int _id;
    public int Weight { get; }

    public Gift()
    {
        _status = Status.Ordered;
        _id = Interlocked.Increment(ref _counter);
        Weight = Random.Shared.Next(1, 100);
        Console.WriteLine(this);
    }

    public void Assemble()
    {
        if (_status != Status.Ordered) 
            throw new InvalidOperationException("Gift status must be ordered");
        Thread.Sleep(Weight);
        _status = Status.Assembled;
        Console.WriteLine(this);
    }
    
    public void Wrap()
    {
        if (_status != Status.Assembled) 
            throw new InvalidOperationException("Gift status must be assembled");
        Thread.Sleep(Weight / 2);
        _status = Status.Wrapped;
        Console.WriteLine(this);
    }
    
    public void Deliver()
    {
        if (_status != Status.Wrapped) 
            throw new InvalidOperationException("Gift status must be wrapped");
        Thread.Sleep(Random.Shared.Next(10, 50));
        _status = Status.Delivered;
        Console.WriteLine(this);
    }

    public override string ToString()
    {
        return $"Gift {_id}: {_status}";
    }
    
    private static int _counter;
    public enum Status
    {
        Ordered, Assembled, Wrapped, Delivered
    }
}