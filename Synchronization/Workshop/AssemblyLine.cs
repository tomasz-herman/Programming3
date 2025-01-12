namespace Workshop;

public class AssemblyLine : IAssemblyLine<Gift>
{
    // TODO: Implement assembly line class in a thread-safe way.
    public AssemblyLine(int capacity)
    {
        
    }
    
    public Gift Dequeue()
    {
        throw new NotImplementedException();
    }

    public void Enqueue(Gift item)
    {
        throw new NotImplementedException();
    }

    public Task<Gift?> TryDequeueAsync(int timeoutMilliseconds, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TryEnqueueAsync(Gift item, int timeoutMilliseconds, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}