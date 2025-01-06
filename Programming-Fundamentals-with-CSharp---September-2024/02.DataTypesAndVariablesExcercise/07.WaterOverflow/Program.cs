using System;

namespace _07.WaterOverflow;

internal class Program
{
    static void Main(string[] args)
    {
        int capacity = 255;
        int quantity = 0;

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            int liters = int.Parse(Console.ReadLine());

            if (quantity + liters > capacity)
            {
                Console.WriteLine("Insufficient capacity!");
            }
            else
            {
                quantity += liters;
            }
        }

        Console.WriteLine(quantity);
    }
}
