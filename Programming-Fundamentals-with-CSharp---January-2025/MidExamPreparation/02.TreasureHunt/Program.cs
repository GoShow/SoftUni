using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> chest = Console.ReadLine()
            .Split('|')
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "Yohoho!")
        {
            string[] tokens = command.Split();
            string action = tokens[0];

            switch (action)
            {
                case "Loot":
                    string[] items = tokens.Skip(1).ToArray();
                    InsertLoot(items, chest);
                    break;
                case "Drop":
                    Drop(int.Parse(tokens[1]), chest);
                    break;
                case "Steal":
                    Steal(int.Parse(tokens[1]), chest);
                    break;
            }
        }

        if (chest.Count > 0)
        {
            //double averageGain = chest.Sum(loot => loot.Length) / (double)chest.Count;
            //double averageGain = chest.Average(loot => loot.Length);

            double averageGain = 0;

            foreach (string loot in chest)
            {
                averageGain += loot.Length;
            }

            averageGain /= chest.Count;

            Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
        }
        else
        {
            Console.WriteLine("Failed treasure hunt.");
        }
    }

    static void InsertLoot(string[] items, List<string> chest)
    {
        for (int i = 0; i < items.Length; i++)
        {
            string item = items[i];

            if (!chest.Contains(item))
            {
                chest.Insert(0, item);
            }
        }
    }

    static void Drop(int index, List<string> chest)
    {
        if (index >= 0 && index < chest.Count)
        {
            string item = chest[index];

            chest.RemoveAt(index);
            chest.Add(item);
        }
    }

    static void Steal(int count, List<string> chest)
    {
        count = Math.Min(count, chest.Count);

        List<string> stolenItems = new();

        for (int i = 0; i < count; i++)
        {
            string stolenItem = chest[chest.Count - 1];

            stolenItems.Insert(0, stolenItem);

            chest.RemoveAt(chest.Count - 1);
        }

        Console.WriteLine(string.Join(", ", stolenItems));
    }
}
