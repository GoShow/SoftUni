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
        string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IVehicle car = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3])); //create Car
        vehicles.Add(car);

        tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IVehicle truck = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3])); //create Truck
        vehicles.Add(truck);

        tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IVehicle bus = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3])); //create Bus
        vehicles.Add(bus);

        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
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

                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "DriveEmpty")
            {
                if (vehicle is ISpecializedVehicle specializedVehicle)
                {
                    double distance = double.Parse(commandTokens[2]);

                    writer.WriteLine(((ISpecializedVehicle)vehicle).DriveEmpty(distance));
                }
            }
            else if (command == "Refuel")
            {
                double fuelAmount = double.Parse(commandTokens[2]);

                string refuelMessage = vehicle.Refuel(fuelAmount);

                if (refuelMessage != "Refueled")
                {
                    writer.WriteLine(refuelMessage);
                }
            }
        }

        foreach (var vehicle in vehicles)
        {
            writer.WriteLine(vehicle.ToString());
        }
    }
}
