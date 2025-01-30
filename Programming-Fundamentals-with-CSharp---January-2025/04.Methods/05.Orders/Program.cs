using System;

namespace _05.Orders;

internal class Program
{
    static void Main(string[] args)
    {
        string product = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());

        PrintOrder(product, quantity);
    }

    static void PrintOrder(string product, int quantity)
    {
        decimal coffeePrice = 1.5m;
        decimal waterPrice = 1m;
        decimal cokePrice = 1.4m;
        decimal snacksPrice = 2m;

        switch (product)
        {
            case "coffee":
                Console.WriteLine($"{(quantity * coffeePrice):f2}");
                break;
            case "water":
                Console.WriteLine($"{(quantity * waterPrice):f2}");
                break;
            case "coke":
                Console.WriteLine($"{(quantity * cokePrice):f2}");
                break;
            case "snacks":
                Console.WriteLine($"{(quantity * snacksPrice):f2}");
                break;
        }
    }
}
