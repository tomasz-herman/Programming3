namespace Workshop;

public class AssemblyLine<T> : IAssemblyLine<T>
{
    // TODO: Implement assembly line class in a thread-safe way.
    public AssemblyLine(int capacity)
    {
        
    }
    
    public T Dequeue()
    {
        throw new NotImplementedException();
    }

    public void Enqueue(T item)
    {
        throw new NotImplementedException();
    }

    public Task<T?> TryDequeueAsync(int timeoutMilliseconds, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TryEnqueueAsync(T item, int timeoutMilliseconds, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}