using System;
using System.Collections.Generic;

namespace _03.WordSynonyms;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> wordsSynonyms = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string word = Console.ReadLine();
            string synonym = Console.ReadLine();

            if (!wordsSynonyms.ContainsKey(word))
            {
                wordsSynonyms[word] = new List<string>();
            }

            wordsSynonyms[word].Add(synonym);
        }

        //foreach (KeyValuePair<string, List<string>> wordSynonyms in wordsSynonyms)
        //{
        //    Console.WriteLine($"{wordSynonyms.Key} - {string.Join(", ", wordSynonyms.Value)}");
        //}

        foreach ((string word, List<string> synonyms) in wordsSynonyms)
        {
            Console.WriteLine($"{word} - {string.Join(", ", synonyms)}");
        }
    }
}
