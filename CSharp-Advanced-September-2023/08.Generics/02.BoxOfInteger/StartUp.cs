using BoxOfInteger;
using System;

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    int value = int.Parse(Console.ReadLine());

    Box<int> box = new(value);

    Console.WriteLine(box.ToString());
}