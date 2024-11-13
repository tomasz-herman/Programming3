namespace EventStandardPattern;

public class PriceChangedEventArgs : System.EventArgs
{
    public decimal LastPrice { get; }
    public decimal NewPrice { get; }

    public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
    {
        LastPrice = lastPrice;
        NewPrice = newPrice;
    }
}

// System EventHandler
// public delegate void EventHandler<TEventArgs>(object source, TEventArgs e);

public class Stock(string symbol, decimal price)
{
    public string Symbol { get; } = symbol;
    public event EventHandler<PriceChangedEventArgs>? PriceChanged;
    
    private decimal _price = price;
    public decimal Price 
    { 
        get => _price; 
        set
        {
            if (_price == value) return;
            decimal oldPrice = _price;
            _price = value;
            OnPriceChanged(new PriceChangedEventArgs(oldPrice, _price));
        }
    }
    
    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    {
        if (PriceChanged != null) PriceChanged(this, e);
    }
}