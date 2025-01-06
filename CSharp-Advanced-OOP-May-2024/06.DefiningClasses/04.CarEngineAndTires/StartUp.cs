using System;

namespace CarManufacturer;

public class StartUp
{
    static void Main()
    {
        Tire[] tires =
        {
            new Tire(1, 2.5),
            new Tire(1, 2.1),
            new Tire(2, 0.5),
            new Tire(2, 2.3),
        };

        Engine engine = new(560, 6.300);

        Car car = new("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

        Console.WriteLine(car.WhoAmI());
    }
}
