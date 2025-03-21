using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords;

internal class Program
{
    static void Main(string[] args)
    {
        string pattern = @"([@#])(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";

        string input = Console.ReadLine();

        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count == 0)
        {
            Console.WriteLine("No word pairs found!");
            Console.WriteLine("No mirror words!");

            return;
        }

        Console.WriteLine($"{matches.Count} word pairs found!");

        List<string> mirrorWords = GetMirrorWords(matches);

        if (mirrorWords.Count == 0)
        {
            Console.WriteLine("No mirror words!");

            return;
        }

        Console.WriteLine("The mirror words are:");
        Console.WriteLine(string.Join(", ", mirrorWords));
    }

    static List<string> GetMirrorWords(MatchCollection matches)
    {
        List<string> mirrorWords = new();

        foreach (Match match in matches)
        {
            string word1 = match.Groups["word1"].Value;
            string word2 = match.Groups["word2"].Value;

            string reversedWord2 = new(word2.Reverse().ToArray());

            if (word1 == reversedWord2)
            {
                mirrorWords.Add($"{word1} <=> {word2}");
            }
        }

        return mirrorWords;
    }
}
