using System.Collections.Concurrent;

namespace SynchronizationContexts;

public class MySynchronizationContext : SynchronizationContext
{
    private readonly BlockingCollection<(SendOrPostCallback Callback, object? State)> _workItems = new();

    private readonly Thread _processingThread;

    public MySynchronizationContext()
    {
        _processingThread = new Thread(ProcessQueue)
        {
            IsBackground = true,
            Name = "SynchronizationContext processing thread"
        };
        _processingThread.Start();
    }

    public override void Post(SendOrPostCallback callback, object? state)
    {
        if (callback == null) throw new ArgumentNullException(nameof(callback));

        _workItems.Add((callback, state));
    }

    private void ProcessQueue()
    {
        foreach (var (callback, state) in _workItems.GetConsumingEnumerable())
        {
            try
            {
                callback(state);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Exception in synchronization context: {ex}");
            }
        }
    }

    public void Dispose()
    {
        _workItems.CompleteAdding();
        _processingThread.Join();
    }
}