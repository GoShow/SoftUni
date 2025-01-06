using System;
using System.Collections.Generic;
using System.Linq;

double[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();

Dictionary<double, int> numbersCounts = new();

foreach (double number in numbers)
{
    if (!numbersCounts.ContainsKey(number))
    {
        numbersCounts.Add(number, 0);
    }

    numbersCounts[number]++;
}

foreach (KeyValuePair<double, int> numberCount in numbersCounts)
{
    Console.WriteLine($"{numberCount.Key} - {numberCount.Value} times");
}