using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity
    {
        get => fuelQuantity;
        private set
        {
            if (TankCapacity < value)
            {
                fuelQuantity = 0;
            }
            else
            {
                fuelQuantity = value;
            }
        }
    }

    public virtual double FuelConsumption { get; protected set; }

    public double TankCapacity { get; private set; }

    public string Drive(double distance)
    {
        if (FuelQuantity < distance * FuelConsumption)
        {
            return $"{GetType().Name} needs refueling";
        }

        FuelQuantity -= distance * FuelConsumption;

        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual string Refuel(double amount)
    {
        if (amount <= 0)
        {
            return "Fuel must be a positive number";
        }

        if (amount + FuelQuantity > TankCapacity)
        {
            return $"Cannot fit {amount} fuel in the tank";
        }

        FuelQuantity += amount;

        return "Refueled";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}
