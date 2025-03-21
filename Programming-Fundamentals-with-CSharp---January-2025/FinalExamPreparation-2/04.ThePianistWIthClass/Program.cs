using System;
using System.Collections.Generic;

namespace _04.ThePianistWIthClass;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Piece> pieces = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            string pieceName = tokens[0];
            string composer = tokens[1];
            string key = tokens[2];

            pieces.Add(pieceName, new Piece(pieceName, composer, key));
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

        foreach ((string pieceName, Piece piece) in pieces)
        {
            Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
        }
    }

    static void Add(string pieceName, string composer, string key, Dictionary<string, Piece> pieces)
    {
        if (pieces.ContainsKey(pieceName))
        {
            Console.WriteLine($"{pieceName} is already in the collection!");
        }
        else
        {
            pieces.Add(pieceName, new Piece(pieceName, composer, key));

            Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
        }
    }

    static void Remove(string pieceName, Dictionary<string, Piece> pieces)
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

    static void ChangeKey(string pieceName, string newKey, Dictionary<string, Piece> pieces)
    {
        if (pieces.ContainsKey(pieceName))
        {
            Piece piece = pieces[pieceName];

            piece.Key = newKey;

            Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
        }
    }
}

public class Piece
{
    public Piece(string name, string composer, string key)
    {
        Name = name;
        Composer = composer;
        Key = key;
    }

    public string Name { get; set; }
    public string Composer { get; set; }
    public string Key { get; set; }
}