using System;


internal class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        int meters = int.Parse(input);

        double kilometers = meters / 1000.0;

        Console.WriteLine($"{kilometers:f2}");
    }
}