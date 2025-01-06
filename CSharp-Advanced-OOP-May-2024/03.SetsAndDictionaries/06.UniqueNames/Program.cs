using System;
using System.Collections.Generic;

int count = int.Parse(Console.ReadLine());

HashSet<string> names = new();

for (int i = 0; i < count; i++)
{
    names.Add(Console.ReadLine());
}

Console.WriteLine(string.Join(Environment.NewLine, names));
