using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> wordsCounts = new();

        string[] words = Console.ReadLine()
            .Split()
            .Select(word => word.ToLower())
            .ToArray();

        foreach (string word in words)
        {
            if (!wordsCounts.ContainsKey(word))
            {
                wordsCounts.Add(word, 0);
            }

            wordsCounts[word]++;
        }

        string[] oddCountWords = wordsCounts
            .Where(w => w.Value % 2 != 0)
            .Select(w => w.Key)
            .ToArray();

        Console.WriteLine(string.Join(" ", oddCountWords));
    }
}
