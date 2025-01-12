namespace Workshop;

public interface IAssemblyLine<T>
{
    public T Dequeue();
    public void Enqueue(T item);
    public Task<T?> TryDequeueAsync(int timeoutMilliseconds, CancellationToken cancellationToken);
    public Task<bool> TryEnqueueAsync(T item, int timeoutMilliseconds, CancellationToken cancellationToken);
}