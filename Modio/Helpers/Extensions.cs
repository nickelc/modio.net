using System.Collections.Generic;

namespace Modio;

internal static class DictionaryExtensions
{
    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        where TKey : notnull
        where TValue : new()
    {
        TValue value;
        if (!dict.TryGetValue(key, out value))
        {
            value = new TValue();
            dict.Add(key, value);
        }
        return value;
    }

    public static void Extend<T, K, V>(this T dict, params IDictionary<K, V>[] others)
        where T : IDictionary<K, V>
        where K : notnull
    {
        foreach (var other in others)
        {
            foreach (var (key, value) in other)
            {
                dict[key] = value;
            }
        }
    }
}

internal static class KeyValuePairExtensions
{
#if NETSTANDARD2_0
    public static void Deconstruct<T, V>(this KeyValuePair<T, V> kvp, out T key, out V value)
    {
        key = kvp.Key;
        value = kvp.Value;
    }
#endif
}