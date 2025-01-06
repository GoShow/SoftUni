using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models;

public class Bus : Vehicle, ISpecializedVehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    { }

    public override double FuelConsumption => base.FuelConsumption + 1.4;

    public bool DriveEmpty(double distance)
    {
        return Drive(distance, base.FuelConsumption);
    }
}
