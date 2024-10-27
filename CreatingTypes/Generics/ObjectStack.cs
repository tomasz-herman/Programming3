namespace Generics;

public class ObjectStack
{
    private object[] _items = new object[8];
    public int Count { get; private set; }

    public void Push(object item)
    {
        if (_items.Length == Count)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[Count++] = item;
    }

    public object Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _items[--Count];
    }
}