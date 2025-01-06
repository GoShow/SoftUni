using System;
using System.Linq;

int[] sortedEvenNumbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .Where(number => number % 2 == 0)
    .OrderBy(n => n)
    .ToArray();

Console.WriteLine(string.Join(", ", sortedEvenNumbers));