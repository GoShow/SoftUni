using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        bool hasChanges = false;

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
                case "Contains":
                    int numberToCheck = int.Parse(tokens[1]);
                    string result = numbers.Contains(numberToCheck)
                        ? "Yes"
                        : "No such number";
                    Console.WriteLine(result);
                    hasChanges = true;
                    break;
                case "PrintEven":
                    List<int> evenNumbers = numbers.FindAll(n => n % 2 == 0);
                    Console.WriteLine(string.Join(" ", evenNumbers));
                    hasChanges = true;
                    break;
                case "PrintOdd":
                    List<int> oddNumbers = numbers.FindAll(n => n % 2 != 0);
                    Console.WriteLine(string.Join(" ", oddNumbers));
                    hasChanges = true;
                    break;
                case "GetSum":
                    int sum = numbers.Sum();
                    Console.WriteLine(sum);
                    hasChanges = true;
                    break;
                case "Filter":
                    string condition = tokens[1];
                    int number = int.Parse(tokens[2]);

                    List<int> filteredNumbers = new();

                    if (condition == "<")
                    {
                        filteredNumbers = numbers.FindAll(n => n < number);
                    }
                    else if (condition == "<=")
                    {
                        filteredNumbers = numbers.FindAll(n => n <= number);
                    }
                    else if (condition == ">")
                    {
                        filteredNumbers = numbers.FindAll(n => n > number);
                    }
                    else if (condition == ">=")
                    {
                        filteredNumbers = numbers.FindAll(n => n >= number);
                    }

                    Console.WriteLine(string.Join(" ", filteredNumbers));
                    hasChanges = true;
                    break;
            }
        }

        if (!hasChanges)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

