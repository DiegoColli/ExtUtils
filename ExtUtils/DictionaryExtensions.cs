using System.Runtime.InteropServices;

namespace ExtUtils;

public static class DictionaryExtensions
{
    /// <summary> NOT SAFE: Items should not be added or removed from the Dictionary while the is in use.</summary>
    public static void AddOrUpdate <TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) where TKey : notnull
    {
        ref var valOrNew = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out var exists);
        valOrNew = value;
    }
    
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        where TKey: notnull
        where TValue: new()
    {
        if (dictionary.TryGetValue(key, out var existingValue))
        {
            return existingValue;
        }

        return dictionary[key] = new TValue();
    }
    
    public static IDictionary<TKey, TValue> MergeDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue>? second) where TKey : notnull
    {
        if (second == null) return new Dictionary<TKey, TValue>(dictionary);
        
        var result = new Dictionary<TKey, TValue>(dictionary);
        foreach (var kvp in second)
        {
            result[kvp.Key] = kvp.Value;
        }
        return result;
    }

}