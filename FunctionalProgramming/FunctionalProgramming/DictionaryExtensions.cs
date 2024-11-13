using System.Collections.Immutable;

namespace FunctionalProgramming;

/// <summary>
/// Implement the extension method for the IDictionary&lt;TKey, TValue&gt; interface named AddOrUpdate.
/// This method should add new elements to the dictionary if the value for the specified key does not exist
/// or update the existing value based on the key and the previous value. <br/>
/// The method should accept the following parameters:<br/>
/// - TKey key: the key to be added or updated<br/>
/// - TValue addValue: the value to be added if the key does not exist in the dictionary.<br/>
/// - Func updateValueFactory: a function that, based on the previous value and the key,
///   defines how to update the previous value. It should take the old key TKey
///   and the previous value TValue, and return the new value TValue.<br/>
/// The method should return the newly added value.<br/>
/// Then implement the CountWords method that counts the occurrences of words in a sequence of strings
/// using the previously implemented method. This method should return IDictionary&lt;string, int&gt;,
/// where the key is the word, and the value is the number of occurrences in the sequence.
/// </summary>
public static class DictionaryExtensions
{
    // TODO: AddOrUpdate<TKey, TValue>

    public static IDictionary<string, int> CountWords(IEnumerable<string> words)
    {
        // TODO: CountWords
        return ImmutableDictionary<string, int>.Empty;
    }
}

// SOLUTION
// public static class DictionaryExtensions
// {
//     public static TValue AddOrUpdate<TKey, TValue>(
//         this IDictionary<TKey, TValue> dictionary,
//         TKey key,
//         TValue addValue,
//         Func<TKey, TValue, TValue> updateValueFactory)
//         where TKey : notnull
//     {
//         return dictionary.TryAdd(key, addValue) ? addValue : (dictionary[key] = updateValueFactory(key, dictionary[key]));
//     }
//
//     public static IDictionary<string, int> CountWords(IEnumerable<string> words)
//     {
//         var counts = new Dictionary<string, int>();
//         foreach (var word in words)
//         {
//             counts.AddOrUpdate(word, 1, (_, count) => count + 1);
//         }
//
//         return counts;
//     }
// }