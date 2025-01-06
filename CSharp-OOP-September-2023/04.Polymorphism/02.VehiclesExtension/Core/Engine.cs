using System;
using System.Collections.Generic;
using System.Linq;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.IO.Interfaces;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IVehicleFactory vehicleFactory;

    private readonly ICollection<IVehicle> vehicles;

    public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.vehicleFactory = vehicleFactory;

        vehicles = new List<IVehicle>();
    }

    public void Run()
    {
        vehicles.Add(CreateVehicle()); //add Car
        vehicles.Add(CreateVehicle()); //add Truck
        vehicles.Add(CreateVehicle()); //add Bus

        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            try
            {
                ProcessCommand();
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        foreach (var vehicle in vehicles)
        {
            writer.WriteLine(vehicle.ToString());
        }
    }

    private void ProcessCommand()
    {
        string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string command = commandTokens[0];
        string vehicleType = commandTokens[1];

        IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

        if (vehicle == null)
        {
            throw new ArgumentException("Invalid vehicle type");
        }

        if (command == "Drive")
        {
            double distance = double.Parse(commandTokens[2]);

            bool isDriven = vehicle.Drive(distance);

            if (isDriven)
            {
                writer.WriteLine($"{vehicleType} travelled {distance} km");
            }
            else
            {
                writer.WriteLine($"{vehicleType} needs refueling");
            }
        }
        else if (command == "DriveEmpty")
        {
            if (vehicle is ISpecializedVehicle specializedVehicle)
            {
                double distance = double.Parse(commandTokens[2]);

                bool isDriven = specializedVehicle.DriveEmpty(distance);

                if (isDriven)
                {
                    writer.WriteLine($"{vehicleType} travelled {distance} km");
                }
                else
                {
                    writer.WriteLine($"{vehicleType} needs refueling");
                }
            }
        }
        else if (command == "Refuel")
        {
            double fuelAmount = double.Parse(commandTokens[2]);

            bool isRefueled = vehicle.Refuel(fuelAmount);

            if (!isRefueled)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            }
        }
    }

    private IVehicle CreateVehicle()
    {
        string[] tokens = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

        return vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));
    }
}
