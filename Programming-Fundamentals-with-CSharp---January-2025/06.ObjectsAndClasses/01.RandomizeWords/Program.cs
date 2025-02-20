using System;

namespace _01.RandomizeWords;

internal class Program
{
    static void Main(string[] args)
    {
        string[] words = Console.ReadLine().Split();

        Random random = new();

        for (int i = 0; i < words.Length; i++)
        {
            int randomIndex = random.Next(0, words.Length);

            SwapWords(i, randomIndex, words);
        }

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }

    static void SwapWords(int firstIndex, int secondIndex, string[] words)
    {
        string temp = words[firstIndex];
        words[firstIndex] = words[secondIndex];
        words[secondIndex] = temp;
    }
}