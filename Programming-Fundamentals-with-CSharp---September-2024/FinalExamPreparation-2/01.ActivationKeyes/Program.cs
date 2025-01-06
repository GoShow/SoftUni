using System;

namespace _01.ActivationKeys;

internal class Program
{
    static void Main(string[] args)
    {
        string key = Console.ReadLine();

        string command = null;
        while ((command = Console.ReadLine()) != "Generate")
        {
            string[] tokens = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];

            switch (action)
            {
                case "Contains":
                    Contains(tokens[1], key);
                    break;
                case "Flip":
                    key = Flip(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]), key);
                    Console.WriteLine(key);
                    break;
                case "Slice":
                    key = Slice(int.Parse(tokens[1]), int.Parse(tokens[2]), key);
                    Console.WriteLine(key);
                    break;
            }
        }

        Console.WriteLine($"Your activation key is: {key}");
    }

    static void Contains(string substring, string key)
    {
        if (key.Contains(substring))
        {
            Console.WriteLine($"{key} contains {substring}");
        }
        else
        {
            Console.WriteLine("Substring not found!");
        }
    }

    static string Flip(string casing, int startIndex, int endIndex, string key)
    {
        string originalSubstring = key.Substring(startIndex, endIndex - startIndex);

        string newSubstring = casing == "Upper"
            ? originalSubstring.ToUpper()
            : originalSubstring.ToLower();

        string beforeSubstring = key.Substring(0, startIndex);
        string afterSubstring = key.Substring(endIndex);

        key = beforeSubstring + newSubstring + afterSubstring;

        return key;
    }

    static string Slice(int startIndex, int endIndex, string key)
    {
        key = key.Remove(startIndex, endIndex - startIndex);

        return key;
    }
}