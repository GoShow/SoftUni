namespace VehiclesExtension.Models.Interfaces;

public interface IVehicle
{
    double FuelQuantity { get; }

    double FuelConsumption { get; }

    bool Drive(double distance);

    bool Drive(double distance, double fuelConsumption)

    bool Refuel(double amount);
}
