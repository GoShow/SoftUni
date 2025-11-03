namespace VehiclesExtension.Models;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    { }

    public override double FuelConsumption => base.FuelConsumption + 0.9;
}
