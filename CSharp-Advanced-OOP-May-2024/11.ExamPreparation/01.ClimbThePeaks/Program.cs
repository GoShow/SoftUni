using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> peaksDifficulties = new()
        {
            { "Vihren", 80},
            { "Kutelo", 90},
            { "Banski Suhodol", 100},
            { "Polezhan", 60},
            { "Kamenitza", 70}
        };

        Queue<string> peaks = new(peaksDifficulties.Keys);
        List<string> conqueredPeaks = new();

        Stack<int> foodPortions = new(Console.ReadLine().Split(", ").Select(int.Parse));
        Queue<int> staminaQuantities = new(Console.ReadLine().Split(", ").Select(int.Parse));

        while (foodPortions.Any() && staminaQuantities.Any() && peaks.Any())
        {
            int foodPortion = foodPortions.Pop();
            int staminaQuantity = staminaQuantities.Dequeue();
            string peakName = peaks.Peek();
            int peakDifficulty = peaksDifficulties[peakName];

            if (foodPortion + staminaQuantity >= peakDifficulty)
            {
                conqueredPeaks.Add(peaks.Dequeue());
            }
        }

        if (!peaks.Any())
        {
            Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
        }
        else
        {
            Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
        }

        if (conqueredPeaks.Any())
        {
            Console.WriteLine("Conquered peaks:");
            foreach (string peak in conqueredPeaks)
            {
                Console.WriteLine(peak);
            }
        }
    }
}