#define CONSUMING_ENUMERABLE

using System.Collections.Concurrent;

namespace BlockingCollectionExample;

class Program
{
    static void Main()
    {
        var blockingCollection = new BlockingCollection<int>(5);

        Task producer = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Producing: {i}");
                blockingCollection.Add(i);
                Thread.Sleep(500);
            }
            blockingCollection.CompleteAdding();
        });

        Task consumer = Task.Run(() =>
        {
#if CONSUMING_ENUMERABLE
            foreach (var item in blockingCollection.GetConsumingEnumerable())
            {
                Console.WriteLine($"Consuming: {item}");
                Thread.Sleep(1000);
            }
#else
            try
            {
                while (blockingCollection.Take() is var item)
                {
                    Console.WriteLine($"Consuming: {item}");
                    Thread.Sleep(1000);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Complete Adding was called from elsewhere: {e.Message}");
            }
#endif
        });

        Task.WaitAll(producer, consumer);
    }
}