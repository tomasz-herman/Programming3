namespace EventWaitHandlesExample;

public class Queue<T>
{
    private readonly T?[] _array;
    private int _head;
    private int _tail;
    private int _count;

    private readonly ManualResetEvent _notEmpty;
    private readonly ManualResetEvent _notFull;
    private readonly object _lock;

    public Queue(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        _array = new T[capacity];
        _head = 0;
        _tail = 0;
        _count = 0;

        _notEmpty = new ManualResetEvent(false);
        _notFull = new ManualResetEvent(true);
        _lock = new object();
    }

    public void Enqueue(T item)
    {
        while (true)
        {
            _notFull.WaitOne();

            lock (_lock)
            {
                if (_count < _array.Length)
                {
                    _array[_tail] = item;
                    _tail = (_tail + 1) % _array.Length;
                    _count++;

                    if (_count == _array.Length)
                    {
                        _notFull.Reset();
                    }

                    _notEmpty.Set();
                    return;
                }
            }
        }
    }

    public T Dequeue()
    {
        while (true)
        {
            _notEmpty.WaitOne();

            lock (_lock)
            {
                if (_count > 0)
                {
                    T item = _array[_head]!;
                    _array[_head] = default;
                    _head = (_head + 1) % _array.Length;
                    _count--;

                    if (_count == 0)
                    {
                        _notEmpty.Reset();
                    }

                    _notFull.Set();
                    return item;
                }
            }
        }
    }
}