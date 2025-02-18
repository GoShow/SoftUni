﻿using System;
using System.Text;

namespace _05.DigitsLettersAndOthers;

internal class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        StringBuilder digits = new();
        StringBuilder letters = new();
        StringBuilder others = new();

        foreach (var ch in input)
        {
            if (char.IsDigit(ch))
            {
                digits.Append(ch);
            }
            else if (char.IsLetter(ch))
            {
                letters.Append(ch);
            }
            else
            {
                others.Append(ch);
            }
        }

        //Using LINQ

        //char[] digits = input
        //    .Where(ch => char.IsDigit(ch))
        //    .ToArray();

        //char[] letters = input
        //    .Where(ch => char.IsLetter(ch))
        //    .ToArray();

        //char[] others = input
        //    .Where(ch => !char.IsLetterOrDigit(ch))
        //    .ToArray();

        Console.WriteLine(digits);
        Console.WriteLine(letters);
        Console.WriteLine(others);
    }
}
