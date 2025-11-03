using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    protected Vehicle(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; private set; }

    public virtual double FuelConsumption { get; private set; }

    public string Drive(double distance)
    {
        if (FuelQuantity < distance * FuelConsumption)
        {
            return $"{GetType().Name} needs refueling";
        }

        FuelQuantity -= distance * FuelConsumption;

        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double amount)
        => FuelQuantity += amount;

    public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
}
