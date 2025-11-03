namespace VehiclesExtension.Models;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    { }

    public override double FuelConsumption => base.FuelConsumption + 1.6;

    public override string Refuel(double amount)
    {
        if (amount <= 0)
        {
            return "Fuel must be a positive number";
        }

        if (amount + FuelQuantity > TankCapacity)
        {
            return $"Cannot fit {amount} fuel in the tank";
        }

        return base.Refuel(amount * 0.95);
    }
}
