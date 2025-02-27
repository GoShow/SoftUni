using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers;

internal class Program
{
    static void Main(string[] args)
    {
        SortedDictionary<double, int> numbersCounts = new();

        double[] numbers = Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .ToArray();

        foreach (double number in numbers)
        {
            if (!numbersCounts.ContainsKey(number))
            {
                numbersCounts.Add(number, 0);
            }

            numbersCounts[number]++;
        }

        //foreach (KeyValuePair<double, int> numberCount in numbersCounts)
        //{
        //    Console.WriteLine($"{numberCount.Key} -> {numberCount.Value}");
        //}

        foreach ((double number, int count) in numbersCounts)
        {
            Console.WriteLine($"{number} -> {count}");
        }
    }
}
