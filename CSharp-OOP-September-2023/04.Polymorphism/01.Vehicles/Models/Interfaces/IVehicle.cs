namespace Vehicles.Models.Interfaces;

public interface IVehicle
{
    double FuelQuantity { get; }

    double FuelConsumption { get; }

    bool Drive(double distance);

    void Refuel(double amount);
}
