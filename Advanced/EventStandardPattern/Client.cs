namespace EventStandardPattern;

public class Client(string name)
{
    private string Name { get; } = name;

    public void Watch(Stock stock)
    {
        stock.PriceChanged += OnPriceChanged;
    }

    private void OnPriceChanged(object sender, PriceChangedEventArgs e)
    {
        Stock stock = (Stock)sender;
        if (e.NewPrice < e.LastPrice)
        {
            Console.WriteLine($"{Name} buying {stock.Symbol}");
        }
        else if (e.NewPrice > e.LastPrice)
        {
            Console.WriteLine($"{Name} selling {stock.Symbol}");
        }
    }
}