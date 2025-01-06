using System;

namespace _09.SpiceMustFlow;

internal class Program
{
    static void Main(string[] args)
    {
        int yield = int.Parse(Console.ReadLine());
        int extractedSpices = 0;
        int days = 0;
        int consumation = 26;
        int minYield = 100;
        int yieldDrop = 10;

        while (yield >= minYield)
        {
            extractedSpices += yield - consumation;
            yield -= yieldDrop;
            days++;
        }

        extractedSpices -= consumation;

        if (extractedSpices < 0)
        {
            extractedSpices = 0;
        }

        Console.WriteLine(days);
        Console.WriteLine(extractedSpices);
    }
}
