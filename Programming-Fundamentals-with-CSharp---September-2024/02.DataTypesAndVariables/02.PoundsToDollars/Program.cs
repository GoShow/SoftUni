using System;

namespace _02.PoundsToDollars;

internal class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        decimal pounds = decimal.Parse(input);
        decimal rate = 1.31m;
        decimal result = pounds * rate;

        Console.WriteLine($"{result:f3}");
    }
}
