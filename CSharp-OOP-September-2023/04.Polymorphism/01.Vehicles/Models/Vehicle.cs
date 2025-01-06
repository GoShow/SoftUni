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

    public bool Drive(double distance)
    {
        if (FuelQuantity < distance * FuelConsumption)
        {
            return false;
        }

        FuelQuantity -= distance * FuelConsumption;

        return true;
    }

    public virtual void Refuel(double amount)
        => FuelQuantity += amount;

    public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
}
