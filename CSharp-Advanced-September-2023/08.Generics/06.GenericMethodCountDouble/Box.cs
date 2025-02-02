using System;
using System.Collections.Generic;

namespace GenericMethodCountDouble;

public class Box<T> where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return $"{typeof(T)}: {value}";
    }

    public int CountLarger(List<T> itemsToCompare)
    {
        int count = 0;

        foreach (T item in itemsToCompare)
        {
            if (item.CompareTo(value) > 0)
            {
                count++;
            }
        }

        return count;
    }
}

