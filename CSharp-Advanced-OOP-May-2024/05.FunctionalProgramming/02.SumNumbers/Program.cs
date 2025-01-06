using System;
using System.Linq;

Func<string, int> parseString = s => int.Parse(s);

int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parseString)
    .ToArray();

Console.WriteLine(numbers.Length);
Console.WriteLine(numbers.Sum());


