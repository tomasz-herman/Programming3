using System.Diagnostics;

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

    public async Task<T?> TryDequeueAsync(int timeoutMilliseconds, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> TryEnqueueAsync(T item, int timeoutMilliseconds, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

















// public class AssemblyLine<T> : IAssemblyLine<T>
// {
//     // TODO: Implement assembly line class in a thread-safe way.
//     private List<T> Items { get; set; } = new List<T>();
//     private SemaphoreSlim _itemSemaphore;
//     private SemaphoreSlim _emptySemaphore;
//     public AssemblyLine(int capacity)
//     {
//         _itemSemaphore = new SemaphoreSlim(0, capacity);
//         _emptySemaphore = new SemaphoreSlim(capacity, capacity);
//     }
//     
//     public T Dequeue()
//     {
//         _itemSemaphore.Wait();
//         T ret;
//         lock (Items)
//         {
//             ret = Items[0];
//             Items.RemoveAt(0);
//         }
//         _emptySemaphore.Release();
//         return ret;
//     }
// 
//     public void Enqueue(T item)
//     {
//         _emptySemaphore.Wait();
//         lock (Items)
//             Items.Add(item);
//         _itemSemaphore.Release();
//     }
// 
//     public async Task<T?> TryDequeueAsync(int timeoutMilliseconds, CancellationToken cancellationToken)
//     {
//         try
//         {
//             await _itemSemaphore.WaitAsync(timeoutMilliseconds, cancellationToken);
//         }
//         catch (Exception)
//         {
//             return default;
//         }
//         T ret;
//         lock (Items)
//         {
//             ret = Items[0];
//             Items.RemoveAt(0);
//         }
//         _emptySemaphore.Release();
//         return ret;
//     }
// 
//     public async Task<bool> TryEnqueueAsync(T item, int timeoutMilliseconds, CancellationToken cancellationToken)
//     {
//         try
//         {
//             await _emptySemaphore.WaitAsync(timeoutMilliseconds, cancellationToken);
//         }
//         catch (Exception)
//         {
//             return false;
//         }
//         lock (Items)
//             Items.Add(item);
//         _itemSemaphore.Release();
//         return true;
//     }
// }