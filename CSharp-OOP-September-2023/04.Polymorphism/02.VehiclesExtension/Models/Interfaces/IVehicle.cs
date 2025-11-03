namespace VehiclesExtension.Models.Interfaces;

public interface IVehicle
{
    public double FuelQuantity { get; }

    public double FuelConsumption { get; }

    public string Drive(double distance);

    public string Refuel(double amount);
}