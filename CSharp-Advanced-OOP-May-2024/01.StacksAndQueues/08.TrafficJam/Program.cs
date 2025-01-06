using System;
using System.Collections.Generic;

int passCount = int.Parse(Console.ReadLine());
int totalPasses = 0;

Queue<string> cars = new();

string command;
while ((command = Console.ReadLine()).ToLower() != "end")
{
    if (command.ToLower() == "green")
    {
        int currentPasses = passCount;
        while (cars.Count > 0 && currentPasses > 0)
        {
            currentPasses--;
            totalPasses++;

            Console.WriteLine($"{cars.Dequeue()} passed!");
        }

        continue;
    }

    cars.Enqueue(command);
}

Console.WriteLine($"{totalPasses} cars passed the crossroads.");
