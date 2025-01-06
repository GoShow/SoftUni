using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> targets = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "End")
            {
                break;
            }

            string[] tokens = command.Split();
            string action = tokens[0];
            int index = int.Parse(tokens[1]);

            switch (action)
            {
                case "Shoot":
                    Shoot(index, int.Parse(tokens[2]), targets);
                    break;
                case "Add":
                    Add(index, int.Parse(tokens[2]), targets);
                    break;
                case "Strike":
                    Strike(index, int.Parse(tokens[2]), targets);
                    break;
            }
        }

        Console.WriteLine(string.Join("|", targets));
    }

    static void Shoot(int index, int power, List<int> targets)
    {
        if (index < 0 || index > targets.Count - 1)
        {
            return;
        }

        targets[index] -= power;

        if (targets[index] <= 0)
        {
            targets.RemoveAt(index);
        }
    }

    static void Add(int index, int value, List<int> targets)
    {
        if (index < 0 || index > targets.Count - 1)
        {
            Console.WriteLine("Invalid placement!");

            return;
        }

        targets.Insert(index, value);
    }

    static void Strike(int index, int radius, List<int> targets)
    {
        if (index - radius < 0 || index + radius > targets.Count - 1)
        {
            Console.WriteLine("Strike missed!");

            return;
        }

        targets.RemoveRange(index - radius, radius * 2 + 1);
    }
}
