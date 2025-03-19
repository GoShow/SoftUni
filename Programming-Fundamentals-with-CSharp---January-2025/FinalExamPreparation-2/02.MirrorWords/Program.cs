using System;
using System.Text.RegularExpressions;

namespace _02.MirrorWords;

internal class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"([@#])(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";

        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count == 0)
        {
            Console.WriteLine("No word pairs found!");
            Console.WriteLine("No mirror words!");

            return;
        }

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
