using System.Runtime.InteropServices;

namespace ExtUtils;

public static class DictionaryExtensions
{
    /// <summary> NOT SAFE: Items should not be added or removed from the Dictionary while the is in use.</summary>
    public static void UpdateOrAdd <TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) where TKey : notnull
    {
        ref var valOrNew = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out var exists);

        if (!exists)
        {
            valOrNew = value;
        }
    }
    
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key)
        where TKey: notnull
        where TValue: new()
    {
        if (self.TryGetValue(key, out var existingValue))
        {
            return existingValue;
        }

        return self[key] = new TValue();
    }

}