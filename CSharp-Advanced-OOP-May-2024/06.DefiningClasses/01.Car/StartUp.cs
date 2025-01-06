using System;

namespace CarManufacturer;

public class StartUp
{
    public static void Main()
    {
        Car car = new()
        {
            Make = "Mazda",
            Model = "6",
            Year = 2009
        };

        Console.WriteLine($"Make: {car.Make}");
        Console.WriteLine($"Model: {car.Model}");
        Console.WriteLine($"Year: {car.Year}");
    }
}