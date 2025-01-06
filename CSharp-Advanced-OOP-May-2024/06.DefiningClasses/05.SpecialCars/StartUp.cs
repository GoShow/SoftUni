using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<int, List<Tire>> tires = new();
        Dictionary<int, Engine> engines = new();
        List<Car> cars = new();

        int tiresIndex = 0;
        string command;
        while ((command = Console.ReadLine()) != "No more tires")
        {
            string[] tireTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            tires.Add(tiresIndex, new List<Tire>());

            for (int i = 0; i < tireTokens.Length; i += 2)
            {
                Tire tire = new(int.Parse(tireTokens[i]), double.Parse(tireTokens[i + 1]));

                tires[tiresIndex].Add(tire);
            }

            tiresIndex++;
        }

        int enginesIndex = 0;
        while ((command = Console.ReadLine()) != "Engines done")
        {
            string[] engineTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Engine engine = new(int.Parse(engineTokens[0]), double.Parse(engineTokens[1]));

            engines.Add(enginesIndex, engine);

            enginesIndex++;
        }

        while ((command = Console.ReadLine()) != "Show special")
        {
            string[] carTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string make = carTokens[0];
            string model = carTokens[1];
            int year = int.Parse(carTokens[2]);
            double fuelQuantity = double.Parse(carTokens[3]);
            double fuelConsumption = double.Parse(carTokens[4]);
            int engineKey = int.Parse(carTokens[5]);
            int tiresKey = int.Parse(carTokens[6]);

            Car car = new(make, model, year, fuelQuantity, fuelConsumption, engines[engineKey], tires[tiresKey].ToArray());

            cars.Add(car);
        }

        IEnumerable<Car> filteredCars = cars
            .Where(car =>
                    car.Year >= 2017 &&
                    car.Engine.HorsePower > 330 &&
                    car.Tires.Sum(t => t.Pressure) > 9 && car.Tires.Sum(t => t.Pressure) < 10);

        foreach (Car car in filteredCars)
        {
            car.Drive(20);
            Console.WriteLine(car.WhoAmI());
        }
    }
}

