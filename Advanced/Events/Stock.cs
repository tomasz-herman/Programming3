namespace Events;

public delegate void PriceChangedHandler(
    string symbol,
    decimal oldPrice,
    decimal newPrice);

public class Stock(string symbol, decimal price)
{
    public string Symbol { get; } = symbol;
    public event PriceChangedHandler? PriceChanged;
    
    private decimal _price = price;
    public decimal Price 
    { 
        get => _price; 
        set
        {
            if (_price == value) return;
            decimal oldPrice = _price;
            _price = value;
            if (PriceChanged != null)
                PriceChanged(Symbol, oldPrice, _price);
        }
    }
}