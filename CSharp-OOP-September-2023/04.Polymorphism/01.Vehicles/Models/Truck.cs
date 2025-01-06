namespace Vehicles.Models;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override void Refuel(double amount)
        => base.Refuel(amount * 0.95);

    public override double FuelConsumption => base.FuelConsumption + 1.6;

}
