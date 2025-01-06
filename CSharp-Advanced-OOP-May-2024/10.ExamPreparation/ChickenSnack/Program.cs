using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> amounts = new(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> prices = new(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

int foodEatenCount = 0;

while (amounts.Count > 0 && prices.Count > 0)
{
    int amount = amounts.Pop();
    int price = prices.Dequeue();

    if (amount < price)
    {
        continue;
    }
    else if (amount == price)
    {
        foodEatenCount++;

        continue;
    }
    else
    {
        amount -= price;

        if (amounts.Count > 0)
        {
            amount += amounts.Pop();
        }

        amounts.Push(amount);

        foodEatenCount++;
    }
}

if (foodEatenCount >= 4)
{
    Console.WriteLine($"Gluttony of the day! Henry ate {foodEatenCount} foods.");
}
else if (foodEatenCount > 0)
{
    string foodString = foodEatenCount == 1 ? "food" : "foods";

    Console.WriteLine($"Henry ate: {foodEatenCount} {foodString}.");
}
else
{
    Console.WriteLine("Henry remained hungry. He will try next weekend again.");
}
