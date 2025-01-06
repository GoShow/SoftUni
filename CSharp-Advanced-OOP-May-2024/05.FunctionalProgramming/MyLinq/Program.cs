using MyLinq;
using System;
using System.Collections.Generic;

List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };

numbers = numbers.Where(n => n % 2 == 0).ToList();

Console.WriteLine(string.Join(", ", numbers));