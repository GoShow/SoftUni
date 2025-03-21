﻿using System;
using System.Collections.Generic;

namespace GenericMethodCountStrings;

public class Box<T> where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
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

    public override string ToString()
    {
        return $"{typeof(T)}: {value}";
    }
}

