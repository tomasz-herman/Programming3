using System.Collections;
using System.ComponentModel;

namespace FunctionalProgramming.Events;

// Create a Shop class that implements the INotifyingCollection<Product> interface,
// according to the following specifications:
// 
// Class Definition and Behavior:
// - The Shop class holds a collection of Product objects,
//   represented by an internal Dictionary<string, Product>.
// - The class must implement these methods:
//   - Add(Product element): Adds a product to the collection,
//     consolidating its quantity if the product already exists.
//     If the product is already present, it updates its price and increments the quantity.
//   - Remove(Product element): Removes a product from the collection by name,
//     based on the product's Name property.
// - Events are raised whenever a product is added, removed, or its properties change:
//   - ElementAdded: Triggered when a product is successfully added to the collection.
//   - ElementRemoved: Triggered when a product is removed from the collection.
//   - ElementPropertyChanged: Triggered when a property on a product changes (e.g., price or quantity).
// - The class must implement the IEnumerable<Product> interface to allow enumeration
//   over the collection of products.
// 
// Specific Requirements for Method Behavior:
// - Add Method:
//   - If a product with the same name already exists in the collection,
//     its price will be updated, and the quantity increased.
//     The method returns false when the product already exists.
//   - If it's a new product, it is added to the dictionary,
//     and the PropertyChanged event for the product is subscribed.
//     The method returns true if the product did not previously exist.
//   - Adding the product triggers the ElementAdded event.
// - Remove Method:
//   - If the product is found (based on the name), it is removed from the dictionary,
//     and the PropertyChanged event for that product is unsubscribed.
//     The method returns true if the product was successfully removed.
//   - Removing the product triggers the ElementRemoved event.
// - Event Handling:
//   - When a product's properties change, the class should handle this change
//     and trigger the ElementPropertyChanged event.



























// SOLUTION: 
// public class Shop : INotifyingCollection<Product>
// {
//     private readonly Dictionary<string, Product> _products = new();
//     
//     public IEnumerator<Product> GetEnumerator()
//     {
//         return _products.Values.GetEnumerator();
//     }
//
//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
//
//     public event EventHandler<CollectionChangedEventArgs<Product>>? ElementAdded;
//     public event EventHandler<CollectionChangedEventArgs<Product>>? ElementRemoved;
//     public event EventHandler<ElementChangedEventArgs<Product>>? ElementPropertyChanged;
//
//     public bool Add(Product element)
//     {
//         if (_products.TryGetValue(element.Name, out var product))
//         {
//             product.Price = element.Price;
//             product.Quantity += element.Quantity;
//             return false;
//         }
//         else
//         {
//             _products.Add(element.Name, element);
//             element.PropertyChanged += OnProductPropertyChanged;
//             OnProductAdded(element);
//             return true;
//         }
//     }
//
//     public bool Remove(Product element)
//     {
//         if (_products.TryGetValue(element.Name, out var product))
//         {
//             product.PropertyChanged -= OnProductPropertyChanged;
//             _products.Remove(element.Name);
//             OnProductRemoved(product);
//             return true;
//         }
//
//         return false;
//     }
//     
//     
//     protected virtual void OnProductAdded(Product product)
//     {
//         ElementAdded?.Invoke(this, new CollectionChangedEventArgs<Product>(product));
//     }
//
//     protected virtual void OnProductRemoved(Product product)
//     {
//         ElementRemoved?.Invoke(this, new CollectionChangedEventArgs<Product>(product));
//     }
//
//     protected virtual void OnProductPropertyChanged(object? sender, PropertyChangedEventArgs e)
//     {
//         if (sender is Product product)
//         {
//             ElementPropertyChanged?.Invoke(this, new ElementChangedEventArgs<Product>(product, e.PropertyName));
//         }
//     }
// }