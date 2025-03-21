using System;

namespace _01.WorldTour;

internal class Program
{
    static void Main(string[] args)
    {
        string stops = Console.ReadLine();

        string command;

        while ((command = Console.ReadLine()) != "Travel")
        {
            string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];

            switch (action)
            {
                case "Add Stop":
                    int index = int.Parse(tokens[1]);
                    string stop = tokens[2];

                    stops = AddStop(index, stop, stops);

                    break;
                case "Remove Stop":
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    stops = RemoveStop(startIndex, endIndex, stops);

                    break;
                case "Switch":
                    string oldString = tokens[1];
                    string replacement = tokens[2];

                    stops = Switch(oldString, replacement, stops);

                    break;
            }

            Console.WriteLine(stops);
        }

        Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
    }

    static string AddStop(int index, string stop, string stops)
    {
        if (IsValidIndex(index, stops))
        {
            stops = stops.Insert(index, stop);
        }

        return stops;
    }

    static string RemoveStop(int startIndex, int endIndex, string stops)
    {
        if (IsValidIndex(startIndex, stops) &&
            IsValidIndex(endIndex, stops) &&
            startIndex <= endIndex)
        {
            string firstHalf = stops.Substring(0, startIndex);
            string secondHalf = stops.Substring(endIndex + 1);

            stops = firstHalf + secondHalf;
        }

        return stops;
    }

    static string Switch(string oldString, string replacement, string stops)
    {
        if (stops.Contains(oldString))
        {
            stops = stops.Replace(oldString, replacement);
        }

        return stops;
    }

    static bool IsValidIndex(int index, string str)
    {
        return index >= 0 && index < str.Length;
    }
}
