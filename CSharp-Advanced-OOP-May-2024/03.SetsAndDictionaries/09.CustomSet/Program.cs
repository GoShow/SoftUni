using _09.CustomSet;
using System;
using System.Collections.Generic;
using System.Diagnostics;


int operations = 20_000;

CustomHashSet customHashSet = new();

customHashSet.Add("sdf");
customHashSet.Add("sdf");

for (int i = 0; i < operations; i++)
{
    customHashSet.Add($"item{i}");
}

Stopwatch stopwatch = Stopwatch.StartNew();
for (int i = 0; i < operations; i++)
{
    customHashSet.Contains($"item{i}");
}

Console.WriteLine(stopwatch.ElapsedMilliseconds);

List<string> list = new();

for (int i = 0; i < operations; i++)
{
    list.Add($"item{i}");
}

stopwatch.Restart();

for (int i = 0; i < operations; i++)
{
    list.Contains($"item-{i}");
}

Console.WriteLine(stopwatch.ElapsedMilliseconds);
