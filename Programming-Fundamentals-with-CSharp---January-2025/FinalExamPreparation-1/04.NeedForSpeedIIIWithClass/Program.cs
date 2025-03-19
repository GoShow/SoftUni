using System;
using System.Collections.Generic;

namespace _04.NeedForSpeedIIIWithClass;

internal class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new();

        int carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            string[] tokens = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            string carName = tokens[0];
            int mileage = int.Parse(tokens[1]);
            int fuel = int.Parse(tokens[2]);

            Car car = new()
            {
                Name = carName,
                Mileage = mileage,
                Fuel = fuel
            };

            cars.Add(car);
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

        foreach (Car car in cars)
        {
            Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
        }
    }

    static void Drive(string carName, int distance, int fuel, List<Car> cars)
    {
        Car car = cars.Find(c => c.Name == carName);

        if (car.Fuel < fuel)
        {
            Console.WriteLine("Not enough fuel to make that ride");
        }
        else
        {
            car.Mileage += distance;
            car.Fuel -= fuel;

            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
        }

        if (car.Mileage >= 100000)
        {
            cars.Remove(car);

            Console.WriteLine($"Time to sell the {carName}!");
        }
    }

    private static void Refuel(string carName, int fuel, List<Car> cars)
    {
        int tankCapacity = 75;

        Car car = cars.Find(c => c.Name == carName);

        if (car.Fuel + fuel > tankCapacity)
        {
            fuel = tankCapacity - car.Fuel;
        }

        car.Fuel += fuel;

        Console.WriteLine($"{carName} refueled with {fuel} liters");
    }

    static void Revert(string carName, int kilometers, List<Car> cars)
    {
        Car car = cars.Find(c => c.Name == carName);

        car.Mileage -= kilometers;

        if (car.Mileage < 10000)
        {
            car.Mileage = 10000;
        }
        else
        {
            Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
        }
    }
}

public class Car
{
    public string Name { get; set; }
    public int Mileage { get; set; }
    public int Fuel { get; set; }
}

