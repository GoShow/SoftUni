using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector;

internal class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();

        string emojisPattern = @"(\*{2}|:{2})(?<emoji>[A-Z][a-z]{2,})\1";
        //string emojisPattern = @"(?<surround>\*{2}|:{2})(?<emoji>[A-Z][a-z]{2,})\k<surround>"; - named first group "surround"
        string numbersPattern = @"\d";

        MatchCollection emojiMatches = Regex.Matches(text, emojisPattern);
        MatchCollection numberMatches = Regex.Matches(text, numbersPattern);

        long treshold = 1;

        foreach (Match numberMatch in numberMatches)
        {
            treshold *= int.Parse(numberMatch.Value);
        }

        Console.WriteLine($"Cool threshold: {treshold}");
        Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");

        foreach (Match emojiMatch in emojiMatches)
        {
            string emoji = emojiMatch.Groups["emoji"].Value;
            long emojiTreshold = emoji.ToCharArray().Sum(c => c);

            if (emojiTreshold >= treshold)
            {
                Console.WriteLine(emojiMatch.Value);
            }
        }
    }
}
