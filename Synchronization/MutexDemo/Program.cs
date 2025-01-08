﻿namespace MutexDemo;

class Program
{
    private static async Task Main()
    {
        int counter = 0, times = 1_000_000;
        using var mutex = new Mutex();
        var increment = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
            {
                mutex.WaitOne(); 
                counter++; 
                mutex.ReleaseMutex();
            }
        });
        var decrement = Task.Run(() =>
        {
            for (int i = 0; i < times; i++)
            {
                mutex.WaitOne(); 
                counter--; 
                mutex.ReleaseMutex();
            }
        });
        
        await Task.WhenAll(increment, decrement);

        Console.WriteLine($"Counter: {counter}");
    }
}