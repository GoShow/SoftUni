namespace CarDealership.Models;

public class SaloonCar : Vehicle
{
    private const double PriceFactor = 1.10;
    public SaloonCar(string model, double price)
        : base(model, price * PriceFactor)
    {
    }
}
