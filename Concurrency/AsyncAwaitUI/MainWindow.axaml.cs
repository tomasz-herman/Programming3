using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AsyncAwaitUI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        int from = (int?)From.Value ?? 0;
        int to = (int?)To.Value ?? 0;
        var primes = await CountPrimesAsync(from, to);
        Result.Content = $"Primes({from}-{to}): {primes}";
    }
    
    private static async Task<int> CountPrimesAsync(int start, int end)
    {
        return await Task.Run(() =>
        {
            int count = 0;

            for (int i = start; i < end; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
            }

            return count;
        });
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}