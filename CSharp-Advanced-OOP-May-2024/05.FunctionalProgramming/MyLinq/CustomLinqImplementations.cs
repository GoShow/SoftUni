using System;
using System.Collections.Generic;

namespace MyLinq;

public static class LinqCustomImplementations
{
    public static IEnumerable<int> Where(this IEnumerable<int> collection, Func<int, bool> filter)
    {
        List<int> items = new();

        foreach (var item in collection)
        {
            if (filter(item))
            {
                items.Add(item);
            }
        }

        return items;
    }

    public static List<int> ToList(this IEnumerable<int> collection)
    {
        List<int> items = new();

        foreach (var item in collection)
        {
            items.Add(item);
        }

        return items;
    }
}
