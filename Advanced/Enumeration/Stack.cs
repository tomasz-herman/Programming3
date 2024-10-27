using System.Collections;

namespace Enumeration;

public class Stack<T> : IEnumerable<T>
{
    private T[] _items = new T[8];
    public int Count { get; private set; }

    public void Push(T item)
    {
        if (_items.Length == Count)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[Count++] = item;
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _items[--Count];
    }

    public IEnumerator<T> GetEnumerator()
    {
        int count = Count;
        while (count-- > 0)
        {
            yield return _items[count];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}