using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FunctionalProgramming.Events;

// Create a Product class implementing the INotifyPropertyChanged interface,
// according to the following specification:
//
// | Property | Type    |
// |----------|---------|
// | Name     | string  |
// | Price    | decimal |
// | Quantity | int     |
//
// Requirements:
// - The class has a constructor that sets all the properties.
//   The Quantity parameter is optional with a default value of 0.
// - The value of Name can only be set within the constructor.
// - Changing the values of Price and Quantity triggers an event
//   defined by the INotifyPropertyChanged interface.
// - Calling ToString returns a string of the form: $"{Name}({Quantity}): {Price:C}".




















// SOLUTION:
// public class Product : INotifyPropertyChanged
// {
//     public event PropertyChangedEventHandler? PropertyChanged;
//
//     public string Name { get; }
//     
//     private decimal _price;
//     public decimal Price
//     {
//         get => _price;
//         set
//         {
//             if (_price == value) return;
//             _price = value;
//             OnPropertyChanged();
//         }
//     }
//     
//     private int _quantity;
//     public int Quantity
//     {
//         get => _quantity;
//         set
//         {
//             if (_quantity == value) return;
//             _quantity = value;
//             OnPropertyChanged();
//         }
//     }
//
//     public Product(string name, decimal price, int quantity = 0)
//     {
//         Name = name;
//         _price = price;
//         _quantity = quantity;
//     }
//
//     protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
//     {
//         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//     }
//
//     public override string ToString() => $"{Name}({Quantity}): {Price:C}";
// }