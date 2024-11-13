namespace Events;

public class Client(string name)
{
    private string Name { get; } = name;

    public void Watch(Stock stock)
    {
        stock.PriceChanged += OnPriceChanged;
    }

    private void OnPriceChanged(string symbol, decimal oldPrice, decimal newPrice)
    {
        if (newPrice < oldPrice)
        {
            Console.WriteLine($"{Name} buying {symbol}");
        }
        else if (newPrice > oldPrice)
        {
            Console.WriteLine($"{Name} selling {symbol}");
        }
    }
}