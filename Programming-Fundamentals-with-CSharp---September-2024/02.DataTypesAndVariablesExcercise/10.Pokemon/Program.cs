using System;

namespace _10.Pokemon;

internal class Program
{
    static void Main(string[] args)
    {
        int power = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        int factor = int.Parse(Console.ReadLine());
        int counter = 0;
        double halfPower = power / 2.0;

        while (power >= distance)
        {
            power -= distance;
            counter++;

            if (power == halfPower && factor != 0)
            {
                power /= factor;
            }
        }

        Console.WriteLine(power);
        Console.WriteLine(counter);
    }
}
