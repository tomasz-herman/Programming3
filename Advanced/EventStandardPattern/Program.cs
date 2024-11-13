namespace EventStandardPattern;

class Program
{
    static void Main(string[] args)
    {
        Stock nvidia = new Stock("NVDA", 149.27m);
        Stock amd = new Stock("AMD", 143.32m);
        Stock broadcom = new Stock("AVGO", 175.49m);

        var stocks = new Dictionary<string, Stock>
        {
            [nvidia.Symbol] = nvidia,
            [amd.Symbol] = amd,
            [broadcom.Symbol] = broadcom,
        };

        foreach (var stock in stocks.Values)
        {
            stock.PriceChanged += StockOnPriceChanged;
        }
        
        Client alice = new Client("Alice");
        alice.Watch(amd);
        Client bob = new Client("Bob");
        bob.Watch(broadcom);
        Client chuck = new Client("Chuck");
        chuck.Watch(amd);
        chuck.Watch(nvidia);
        
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine( "****************");
            Console.WriteLine($"* Day {i + 1,9}*");
            Console.WriteLine( "****************");
            SimulateExchange(stocks);
        }
    }

    private static void StockOnPriceChanged(object sender, PriceChangedEventArgs e)
    {
        Stock? stock = sender as Stock;
        decimal change = (e.NewPrice - e.LastPrice) / e.LastPrice;
        Console.ForegroundColor = change < 0 ? ConsoleColor.Red : ConsoleColor.Green;
        Console.WriteLine($"{stock?.Symbol,4}: {change:P2}");
        Console.ResetColor();
    }

    private static void SimulateExchange(Dictionary<string, Stock> stocks)
    {
        foreach (var stock in stocks.Values)
        {
            decimal change = 0.5m + (decimal)Random.Shared.NextDouble();
            stock.Price *= change;
        }
    }
}