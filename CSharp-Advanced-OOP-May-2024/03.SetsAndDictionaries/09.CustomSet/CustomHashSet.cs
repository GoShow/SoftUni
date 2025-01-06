using System.Collections.Generic;

namespace _09.CustomSet;

public class CustomHashSet
{
    private List<string>[] items = new List<string>[8];
    private int count = 0;
    private double maxCapacityInPercent = 60.0;

    public int GetHashCode(string item)
    {
        int hashCode = 0;

        foreach (var ch in item)
        {
            hashCode += ch;
        }

        return hashCode;
    }

    public void Add(string item)
    {
        int index = GetHashCode(item) % items.Length;
        //int index = Math.Abs(item.GetHashCode() % items.Length);

        if (items[index] == null)
        {
            items[index] = new List<string>();
        }

        if (!Contains(item))
        {
            items[index].Add(item);
            count++;
        }

        if ((double)count / items.Length * 100 > maxCapacityInPercent)
        {
            Resize();
        }
    }

    public bool Contains(string item)
    {
        int index = GetHashCode(item) % items.Length;

        if (items[index] != null)
        {
            for (int i = 0; i < items[index].Count; i++)
            {
                if (items[index][i] == item)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void Resize()
    {
        count = 0;

        List<string>[] currentItems = items;

        items = new List<string>[items.Length * 2];

        for (int i = 0; i < currentItems.Length; i++)
        {
            if (currentItems[i] != null)
            {
                for (int j = 0; j < currentItems[i].Count; j++)
                {
                    Add(currentItems[i][j]);
                }
            }
        }
    }
}
