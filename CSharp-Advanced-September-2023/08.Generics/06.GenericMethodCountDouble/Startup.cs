using GenericMethodCountDouble;
using System;
using System.Collections.Generic;

List<double> items = new();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    items.Add(double.Parse(Console.ReadLine()));
}

Box<double> box = new(double.Parse(Console.ReadLine()));

Console.WriteLine(box.CountLarger(items));

