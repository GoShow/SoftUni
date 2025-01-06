using System;

namespace _08.BeerKegs;

internal class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        string biggestKeg = "";
        double biggestVolume = 0;

        for (int i = 0; i < count; i++)
        {
            string model = Console.ReadLine();
            double radius = double.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double volume = Math.PI * radius * radius * height;

            if (biggestVolume < volume)
            {
                biggestVolume = volume;
                biggestKeg = model;
            }
        }

        Console.WriteLine(biggestKeg);
    }
}
