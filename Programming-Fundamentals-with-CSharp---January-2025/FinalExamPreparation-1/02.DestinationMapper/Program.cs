using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper;

internal class Program
{
    static void Main(string[] args)
    {
        //string pattern = @"(?<delimiter>[=\/])(?<destination>[A-Z][a-z]{2,})\k<delimiter>"; // Named groups

        string pattern = @"([=\/])([A-Z][A-Za-z]{2,})\1";

        string input = Console.ReadLine();

        MatchCollection matches = Regex.Matches(input, pattern);

        //string[] destinations = matches.Select(m => m.Groups["destination"].Value).ToArray(); // Named groups

        string[] destinations = matches.Select(m => m.Groups[2].Value).ToArray();

        int travelPoints = destinations.Sum(d => d.Length);

        Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
        Console.WriteLine($"Travel Points: {travelPoints}");
    }
}
