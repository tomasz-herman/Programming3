using System.Collections;

namespace Interfaces;

public class Counter : IEnumerator
{
    public int Count { get; private set; }
    public Counter(int count) => Count = count;
    public bool MoveNext() => Count-- > 0;
    public object Current => Count;
    public void Reset() 
    { 
        throw new NotSupportedException(); 
    }
}