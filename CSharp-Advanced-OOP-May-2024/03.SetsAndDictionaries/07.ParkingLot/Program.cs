using System;
using System.Collections.Generic;

HashSet<string> cars = new();

string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string action = tokens[0];
    string licencePlate = tokens[1];

    switch (action)
    {
        case "IN":
            cars.Add(licencePlate);
            break;
        case "OUT":
            cars.Remove(licencePlate);
            break;
        default:
            break;
    }
}

if (cars.Count == 0)
{
    Console.WriteLine("Parking Lot is Empty");

    return;
}

Console.WriteLine(string.Join(Environment.NewLine, cars));
