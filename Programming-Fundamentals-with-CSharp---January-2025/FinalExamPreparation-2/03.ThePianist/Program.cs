using System;
using System.Collections.Generic;

namespace _03.ThePianist;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> pieces = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            string pieceName = tokens[0];
            string composer = tokens[1];
            string key = tokens[2];

            pieces.Add(pieceName, new List<string> { composer, key });
        }

        string command;
        while ((command = Console.ReadLine()) != "Stop")
        {
            string[] tokens = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];
            string pieceName = tokens[1];

            switch (action)
            {
                case "Add":
                    string composer = tokens[2];
                    string key = tokens[3];

                    Add(pieceName, composer, key, pieces);

                    break;
                case "Remove":
                    Remove(pieceName, pieces);

                    break;
                case "ChangeKey":
                    string newKey = tokens[2];

                    ChangeKey(pieceName, newKey, pieces);

                    break;
            }
        }

        foreach ((string pieceName, List<string> pieceStats) in pieces)
        {
            Console.WriteLine($"{pieceName} -> Composer: {pieceStats[0]}, Key: {pieceStats[1]}");
        }
    }

    static void Add(string pieceName, string composer, string key, Dictionary<string, List<string>> pieces)
    {
        if (pieces.ContainsKey(pieceName))
        {
            Console.WriteLine($"{pieceName} is already in the collection!");
        }
        else
        {
            pieces.Add(pieceName, new List<string> { composer, key });

            Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
        }
    }

    static void Remove(string pieceName, Dictionary<string, List<string>> pieces)
    {
        if (pieces.ContainsKey(pieceName))
        {
            pieces.Remove(pieceName);

            Console.WriteLine($"Successfully removed {pieceName}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
        }
    }

    static void ChangeKey(string pieceName, string newKey, Dictionary<string, List<string>> pieces)
    {
        if (pieces.ContainsKey(pieceName))
        {
            pieces[pieceName][1] = newKey;

            Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
        }
    }
}
