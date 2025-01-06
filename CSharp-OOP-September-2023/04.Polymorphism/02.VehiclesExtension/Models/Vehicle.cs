using System;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models;

public abstract class Vehicle : IVehicle
{
    private double increasedConsumption;
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

    public virtual double FuelConsumption { get; private set; }

    public double TankCapacity { get; private set; }

    public bool Drive(double distance)
    {
        return Drive(distance, FuelConsumption);
    }
    public bool Drive(double distance, double fuelConsumption)
    {
        if (FuelQuantity < distance * fuelConsumption)
        {
            return false;
        }

        FuelQuantity -= distance * fuelConsumption;

        return true;
    }

    public virtual bool Refuel(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (amount + FuelQuantity > TankCapacity)
        {
            return false;
        }

        FuelQuantity += amount;

        return true;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}
