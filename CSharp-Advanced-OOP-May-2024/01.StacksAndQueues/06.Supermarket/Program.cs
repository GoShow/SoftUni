using System;
using System.Collections.Generic;

Queue<string> customers = new();

string input;
while ((input = Console.ReadLine().ToLower()) != "end")
{
    if (input != "paid")
    {
        customers.Enqueue(input);
    }
    else
    {
        while (customers.Count > 0)
        {
            Console.WriteLine(customers.Dequeue());
        }
    }
}

Console.WriteLine($"{customers.Count} people remaining.");