using BoxOfString;
using System;

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    string value = Console.ReadLine();

    Box<string> box = new(value);

    Console.WriteLine(box.ToString());
}

