using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories;
public class VehicleRepository : IRepository<IVehicle>
{
    private readonly List<IVehicle> vehicles;

    public VehicleRepository()
    {
        vehicles = new List<IVehicle>();
    }

    public IReadOnlyCollection<IVehicle> Models => vehicles.AsReadOnly();

    public void Add(IVehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public bool Exists(string model)
    {
        return vehicles.Any(v => v.Model == model);
    }

    public IVehicle Get(string model)
    {
        return vehicles.FirstOrDefault(v => v.Model == model);
    }

    public bool Remove(string model)
    {
        IVehicle vehicle = Get(model);

        return vehicles.Remove(vehicle);
    }
}
