﻿namespace InterlockedDemo;

class Program
{
    private static async Task Main()
    {
        int counter = 0, times = 1_000_000;
        var increment = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
                counter++;
                // Interlocked.Increment(ref counter);
        });
        var decrement = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
                counter--;
                // Interlocked.Decrement(ref counter);
        });
        
        await Task.WhenAll(increment, decrement);

        Console.WriteLine($"Counter: {counter}");
    }
}