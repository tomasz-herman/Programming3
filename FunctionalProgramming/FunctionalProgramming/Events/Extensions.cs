namespace FunctionalProgramming.Events;

// Create an extension method CleanAisles for the Shop class:
// The method removes all products from the shop where the Quantity is less than or equal to 0.





















// SOLUTION:
// public static class Extensions
// {
//     public static void CleanAisles(this Shop shop)
//     {
//         var products = shop.Where(product => product.Quantity <= 0).ToList();
//
//         foreach (var product in products)
//         {
//             shop.Remove(product);
//         }
//     }
// }