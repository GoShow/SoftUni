using System;
using System.Collections.Generic;
using System.Linq;

int count = int.Parse(Console.ReadLine());
Dictionary<string, List<decimal>> students = new();

for (int i = 0; i < count; i++)
{
    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = tokens[0];
    decimal grade = decimal.Parse(tokens[1]);

    if (!students.ContainsKey(name))
    {
        students.Add(name, new List<decimal>());
    }

    students[name].Add(grade);
}

foreach ((string student, List<decimal> grades) in students)
{
    string gradesStr = string.Join(" ", grades.Select(v => v.ToString("f2")));
    string average = $"(avg: {grades.Average():f2})";

    Console.WriteLine($"{student} -> {gradesStr} {average}");
}