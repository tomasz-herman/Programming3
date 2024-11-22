using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Events;

public enum Status
{
    Failed,
    OverLoaded,
    Running,
    Stopped
}

public interface IAddressable
{
    string Address { get; }
}

public class Server(string address, string name, Status status = Status.Stopped, double load = 0.0)
    : IAddressable, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public string Address { get; init; } = address;

    private string _name = name;
    private Status _status = status;
    private double _load = load;

    public string Name
    {
        get => _name;
        set
        {
            if (_name == value) return;
            _name = value;
            OnPropertyChanged();
        }
    }

    public Status Status
    {
        get => _status;
        set
        {
            if (_status == value) return;
            _status = value;
            OnPropertyChanged();
        }
    }

    public double Load
    {
        get => _load;
        set
        {
            if (Math.Abs(_load - value) < 1e-3) return;
            _load = value;
            OnPropertyChanged();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public override string ToString()
    {
        return $"{Name} [{Address}]";
    }
}