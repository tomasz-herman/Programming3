using System.ComponentModel;

namespace FunctionalProgramming.Events;

// Create an INotifyingCollection<T> interface and a corresponding CollectionChangedEventArgs<T> and ElementChangedEventArgs<T> classes according to the following specification:
// 
// Interface: INotifyingCollection<T>
// - It implements the IEnumerable<T> interface.
// - The generic parameter T must implement the INotifyPropertyChanged interface.
// - It contains the following events:
//   - ElementAdded: Raised when an element is added to the collection.
//   - ElementRemoved: Raised when an element is removed from the collection.
//   - ElementPropertyChanged: Raised when a property of an element in the collection changes.
// - It contains two methods:
//   - bool Add(T element): Adds an element to the collection. Returns true if the element is added successfully, otherwise false.
//   - bool Remove(T element): Removes an element from the collection. Returns true if the element is removed successfully, otherwise false.
// 
// Classes: CollectionChangedEventArgs<T> and ElementChangedEventArgs<T>
// 1. CollectionChangedEventArgs<T>:
//    - A sealed class representing the arguments for events that occur when elements are added or removed from the collection.
//    - It has a constructor that accepts a single argument, the element (T element) involved in the event.
//    - It has a single read-only property:
//      - Element of type T, representing the added or removed element.
//
// 2. ElementChangedEventArgs<T>:
//    - A sealed class representing the arguments for events that occur when a property of an element changes.
//    - It has a constructor that takes two arguments: T element, representing the element, and string? propertyName, representing the name of the affected property.
//    - It has two read-only properties:
//      - Element of type T, representing the element whose property was changed.
//      - PropertyName of type string?, representing the name of the changed property.
















// SOLUTION:
// public interface INotifyingCollection<T> : IEnumerable<T>
//     where T : INotifyPropertyChanged
// {
//     event EventHandler<CollectionChangedEventArgs<T>>? ElementAdded;
//     event EventHandler<CollectionChangedEventArgs<T>>? ElementRemoved;
//     event EventHandler<ElementChangedEventArgs<T>>? ElementPropertyChanged;
//
//     bool Add(T element);
//     bool Remove(T element);
// }
//
// public sealed class ElementChangedEventArgs<T>(T element, string? propertyName) : EventArgs
// {
//     public T Element { get; } = element;
//     public string? PropertyName { get; } = propertyName;
// }
//
// public sealed class CollectionChangedEventArgs<T>(T element) : EventArgs
// {
//     public T Element { get; } = element;
// }