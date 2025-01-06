using System;
using System.Collections.Generic;
using System.Linq;

IEnumerable<int> numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .OrderByDescending(n => n)
    .Take(3);

Console.WriteLine(string.Join(" ", numbers));
