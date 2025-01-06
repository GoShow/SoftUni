using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> numbers = new(
    Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

string command = null;

while (command != "end")
{
    command = Console.ReadLine().ToLower();
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (tokens[0] == "add")
    {
        numbers.Push(int.Parse(tokens[1]));
        numbers.Push(int.Parse(tokens[2]));
    }
    else if (tokens[0] == "remove")
    {
        int count = int.Parse(tokens[1]);
        if (count <= numbers.Count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Pop();
            }
        }
    }
}

Console.WriteLine($"Sum: {numbers.Sum()}");
