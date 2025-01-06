using System;

namespace _04.ReverseArrayOfStrings;

internal class Program
{
    static void Main(string[] args)
    {
        string[] strings = Console.ReadLine().Split(' ');

        for (int i = 0; i < strings.Length / 2; i++)
        {
            string temp = strings[i];
            strings[i] = strings[strings.Length - 1 - i];
            strings[strings.Length - 1 - i] = temp;
        }

        Console.WriteLine(string.Join(" ", strings));
    }
}
