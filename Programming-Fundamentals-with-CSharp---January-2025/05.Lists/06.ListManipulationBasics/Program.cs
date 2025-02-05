using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end")
            {
                break;
            }

            string[] tokens = input.Split();

            string command = tokens[0];

            switch (command)
            {
                case "Add":
                    int numberToAdd = int.Parse(tokens[1]);
                    numbers.Add(numberToAdd);
                    break;
                case "Remove":
                    int numberToRemove = int.Parse(tokens[1]);
                    numbers.Remove(numberToRemove);
                    break;
                case "RemoveAt":
                    int indexToRemove = int.Parse(tokens[1]);
                    numbers.RemoveAt(indexToRemove);
                    break;
                case "Insert":
                    int numberToInsert = int.Parse(tokens[1]);
                    int indexToInsert = int.Parse(tokens[2]);
                    numbers.Insert(indexToInsert, numberToInsert);
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}
