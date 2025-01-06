using System;

namespace ShoppingSpree.Models;

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameEmpty);
            }

            name = value;
        }
    }

    public decimal Cost
    {
        get => cost;
        private set
        {
            if (value < 0)
            {
                //For judge exception message should start with money
                throw new ArgumentException(ExceptionMessages.MoneyNegative);
            }

            cost = value;
        }
    }
}
