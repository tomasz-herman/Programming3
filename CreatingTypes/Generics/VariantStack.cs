namespace Generics;

// Covariant T type parameter (can be used only as a return value)
public interface IPoppable<out T> 
{
    T Pop();
}

// Contravariant T type parameter (can be used only as an input parameter)
public interface IPushable<in T> 
{
    void Push(T item);
}

public class VariantStack<T> : IPoppable<T>, IPushable<T>
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
}