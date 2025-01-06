using AutomotiveRepairShop;
using System;

public class StartUp
{
    public static void Main()
    {
        //Initialize the repository (RepairShop)
        RepairShop repairShop = new RepairShop(5);

        //Initialize entity (Vehicle)
        Vehicle vehicle1 = new Vehicle("1HGCM82633A123456", 50000, "Oil leakage");

        //Print Vehicle
        Console.WriteLine(vehicle1); // Damage: Oil leakage, Vehicle: 1HGCM82633A123456 (50000 km)

        //Add Vehicle
        repairShop.AddVehicle(vehicle1);

        //Remove Vehicle
        Console.WriteLine(repairShop.RemoveVehicle("1HGCM82633A123459")); //False
        Console.WriteLine(repairShop.RemoveVehicle("1HGCM82633A123456")); //True

        Vehicle vehicle2 = new Vehicle("5YJSA1CN7DFP12345", 80000, "Overheating issue");
        Vehicle vehicle3 = new Vehicle("JM1GJ1W56F1234567", 120000, "Coolant leakage");
        Vehicle vehicle4 = new Vehicle("2C3CDXAT4CH123456", 95000, "Timing belt failure");
        Vehicle vehicle5 = new Vehicle("WAUZZZ8K9FA123456", 66000, "Cylinder misfire");
        Vehicle vehicle6 = new Vehicle("1G1BL52P3RR123456", 150000, "Transmission failure");
        Vehicle vehicle7 = new Vehicle("JTDKB20U993123456", 65000, "Piston damage");


        //Add More Vehicles
        repairShop.AddVehicle(vehicle2);
        repairShop.AddVehicle(vehicle3);
        repairShop.AddVehicle(vehicle4);
        repairShop.AddVehicle(vehicle5);

        //Get Count
        Console.WriteLine(repairShop.GetCount()); //4

        repairShop.AddVehicle(vehicle6);
        repairShop.AddVehicle(vehicle7);

        //Get Count
        Console.WriteLine(repairShop.GetCount()); //5


        //Get LowestMileage
        Console.WriteLine(repairShop.GetLowestMileage()); //Damage: Cylinder misfire, Vehicle: WAUZZZ8K9FA123456 (66000 km)

        //Report
        Console.WriteLine(repairShop.Report());
        //Vehicles in the preparatory:
        //Damage: Overheating issue, Vehicle: 5YJSA1CN7DFP12345 (80000 km)
        //Damage: Coolant leakage, Vehicle: JM1GJ1W56F1234567 (120000 km)
        //Damage: Timing belt failure, Vehicle: 2C3CDXAT4CH123456 (95000 km)
        //Damage: Cylinder misfire, Vehicle: WAUZZZ8K9FA123456 (66000 km)
        //Damage: Transmission failure, Vehicle: 1G1BL52P3RR123456 (150000 km)

    }
}