using GenericMethodCountStrings;
using System;
using System.Collections.Generic;

List<string> items = new();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    items.Add(Console.ReadLine());
}

Box<string> box = new(Console.ReadLine());

Console.WriteLine(box.Count(items));
