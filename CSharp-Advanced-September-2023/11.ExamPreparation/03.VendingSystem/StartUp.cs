using System;

namespace VendingSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine(6);

            Drink tea = new Drink("Tea", 1.5m, 300);
            Drink coffee = new Drink("Coffee", 2.0m, 120);
            Drink hotChocolate = new Drink("Hot Chocolate", 2.5m, 200);
            Drink latte = new Drink("Latte", 3.5m, 220);
            Drink cappuccino = new Drink("Cappuccino", 2.8m, 180);
            Drink mocha = new Drink("Mocha", 2.1m, 150);
            Drink herbalTea = new Drink("Herbal Tea", 1.75m, 300);

            Console.WriteLine(vendingMachine.GetCount);

            vendingMachine.AddDrink(tea);
            vendingMachine.AddDrink(coffee);
            vendingMachine.AddDrink(hotChocolate);
            vendingMachine.AddDrink(latte);
            vendingMachine.AddDrink(cappuccino);
            vendingMachine.AddDrink(mocha);

            vendingMachine.AddDrink(herbalTea);

            Console.WriteLine(vendingMachine.GetCount);

            Console.WriteLine(vendingMachine.RemoveDrink("Herbal Tea"));
            Console.WriteLine(vendingMachine.RemoveDrink("Tea"));

            Console.WriteLine(vendingMachine.GetLongest());

            Console.WriteLine(vendingMachine.GetCheapest());

            Console.WriteLine(vendingMachine.BuyDrink("Cappuccino"));

            Console.WriteLine(vendingMachine.Report());
        }
    }
}
