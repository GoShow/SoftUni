﻿using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    { }

    public override double FuelConsumption => base.FuelConsumption + 1.6;

    public override bool Refuel(double amount)
    {
        return base.Refuel(amount * 0.95);
    }
}
