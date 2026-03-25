namespace CarDealership.Models;
public class Truck : Vehicle
{
    private const double PriceFactor = 1.30;
    public Truck(string model, double price)
        : base(model, price * PriceFactor)
    {
    }
}
