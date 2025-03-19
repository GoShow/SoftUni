using System;
using System.Collections.Generic;

namespace _03.NeedForSpeedIII;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<int>> cars = new();

        int carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            string[] tokens = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            string carName = tokens[0];
            int mileage = int.Parse(tokens[1]);
            int fuel = int.Parse(tokens[2]);

            cars.Add(carName, new List<int> { mileage, fuel });
        }

        string command;

        while ((command = Console.ReadLine()) != "Stop")
        {
            string[] tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];
            string carName = tokens[1];

            switch (action)
            {
                case "Drive":
                    {
                        Drive(carName, int.Parse(tokens[2]), int.Parse(tokens[3]), cars);

                        break;
                    }

                case "Refuel":
                    {
                        Refuel(carName, int.Parse(tokens[2]), cars);
                        break;
                    }

                case "Revert":
                    {
                        Revert(carName, int.Parse(tokens[2]), cars);

                        break;
                    }
            }
        }

        foreach ((string car, List<int> carStats) in cars)
        {
            Console.WriteLine($"{car} -> Mileage: {carStats[0]} kms, Fuel in the tank: {carStats[1]} lt.");
        }
    }

    static void Drive(string carName, int distance, int fuel, Dictionary<string, List<int>> cars)
    {
        if (cars[carName][1] < fuel)
        {
            Console.WriteLine("Not enough fuel to make that ride");
        }
        else
        {
            cars[carName][0] += distance;
            cars[carName][1] -= fuel;

            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
        }

        if (cars[carName][0] >= 100000)
        {
            cars.Remove(carName);

            Console.WriteLine($"Time to sell the {carName}!");
        }
    }

    private static void Refuel(string carName, int fuel, Dictionary<string, List<int>> cars)
    {
        int tankCapacity = 75;

        if (cars[carName][1] + fuel > tankCapacity)
        {
            fuel = tankCapacity - cars[carName][1];
        }

        cars[carName][1] += fuel;

        Console.WriteLine($"{carName} refueled with {fuel} liters");
    }

    static void Revert(string carName, int kilometers, Dictionary<string, List<int>> cars)
    {
        cars[carName][0] -= kilometers;

        if (cars[carName][0] < 10000)
        {
            cars[carName][0] = 10000;
        }
        else
        {
            Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
        }
    }
}
