namespace EventWaitHandlesExample;

class Program
{
    private static async Task Main()
    {
        Queue<int> queue = new Queue<int>(2);

        Task producerTask = Task.Run(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"Produced {i}");
                await Task.Delay(250);
            }
        });

        Task consumerTask = Task.Run(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                int item = queue.Dequeue();
                Console.WriteLine($"Consuming {item}");
                await Task.Delay(1000);
            }
        });

        await Task.WhenAll(producerTask, consumerTask);

        Console.WriteLine("Finished processing.");
    }
}