using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Models;

public class Dealership : IDealership
{
    private readonly IRepository<IVehicle> vehicles;
    private readonly IRepository<ICustomer> customers;
    public Dealership()
    {
        vehicles = new VehicleRepository();
        customers = new CustomerRepository();
    }

    public IRepository<IVehicle> Vehicles => vehicles;

    public IRepository<ICustomer> Customers => customers;
}
