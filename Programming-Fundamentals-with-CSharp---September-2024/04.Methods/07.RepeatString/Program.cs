using System;

namespace _07.RepeatString;

internal class Program
{
    static void Main(string[] args)
    {
        string str = Console.ReadLine();
        int times = int.Parse(Console.ReadLine());

        Console.WriteLine(RepeatString(str, times));
    }

    static string RepeatString(string str, int times)
    {
        string result = string.Empty;

        for (int i = 0; i < times; i++)
        {
            result += str;
        }

        return result;
    }
}
