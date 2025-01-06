using System;
using System.Linq;

Predicate<string> checkCapitalized = word => char.IsUpper(word[0]);

string[] capitalizedWords = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Where(word => checkCapitalized(word))
    .ToArray();

Console.WriteLine(string.Join(Environment.NewLine, capitalizedWords));