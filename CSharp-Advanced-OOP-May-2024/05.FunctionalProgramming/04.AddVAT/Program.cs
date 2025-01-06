using System;
using System.Linq;

Func<double, double> applyVat = x => x * 1.2;

double[] prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .Select(applyVat)
    .ToArray();

Console.WriteLine(string.Join(Environment.NewLine, prices.Select(p => p.ToString("f2"))));