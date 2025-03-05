using System;

namespace _04.TextFilter;

internal class Program
{
    static void Main(string[] args)
    {
        string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();

        foreach (string bannedWord in bannedWords)
        {
            string replacedWithAsterisks = new('*', bannedWord.Length);

            text = text.Replace(bannedWord, replacedWithAsterisks);
        }

        Console.WriteLine(text);
    }
}
