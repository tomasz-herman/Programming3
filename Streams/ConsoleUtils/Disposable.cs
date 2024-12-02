namespace ConsoleUtils;

public class Disposable(Action disposing) : IDisposable
{
    private Action? _disposing = disposing;

    public void Dispose()
    {
        _disposing?.Invoke();
        _disposing = null;
    }
}