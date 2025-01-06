using System;

namespace CarManufacturer;

public class StartUp
{
    public static void Main()
    {
        string make = Console.ReadLine();
        string model = Console.ReadLine();
        int year = int.Parse(Console.ReadLine());
        double fuelQuantity = double.Parse(Console.ReadLine());
        double fuelConsumption = double.Parse(Console.ReadLine());

        Car firstCar = new();
        Car secondCar = new(make, model, year);
        Car thirdCar = new(make, model, year, fuelQuantity, fuelConsumption);
    }
}