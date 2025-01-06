namespace VehiclesExtension.Models.Interfaces;

public interface IVehicle
{
    public double FuelQuantity { get; }

    public double FuelConsumption { get; }

    public bool Drive(double distance);

    public bool Refuel(double amount);
}