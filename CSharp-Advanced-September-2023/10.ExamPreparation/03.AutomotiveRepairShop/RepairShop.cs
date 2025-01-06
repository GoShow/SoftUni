using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomotiveRepairShop;

public class RepairShop
{
    public RepairShop(int capacity)
    {
        Capacity = capacity;
        Vehicles = new List<Vehicle>();
    }

    public int Capacity { get; private set; }

    public List<Vehicle> Vehicles { get; private set; }

    public void AddVehicle(Vehicle vehicle)
    {
        if (Vehicles.Count < Capacity)
        {
            Vehicles.Add(vehicle);
        }
    }

    public bool RemoveVehicle(string vin) => 
        Vehicles.Remove(Vehicles.FirstOrDefault(v => v.VIN == vin));

    public int GetCount() => Vehicles.Count;

    public Vehicle GetLowestMileage() => Vehicles.MinBy(v => v.Mileage);

    public string Report()
    {
        StringBuilder sb = new();
        
        sb.AppendLine("Vehicles in the preparatory:");

        foreach (Vehicle vehicle in Vehicles)
        {
            sb.AppendLine(vehicle.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}
