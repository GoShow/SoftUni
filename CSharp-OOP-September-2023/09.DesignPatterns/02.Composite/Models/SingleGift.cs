using System;

namespace Composite.Models;

public class SingleGift : GiftBase
{
    public SingleGift(string name, decimal price)
        : base(name, price)
    {
    }

    public override decimal CalculateTotalPrice()
    {
        Console.WriteLine($"{Name} with the price {Price}");

        return Price;
    }
}
