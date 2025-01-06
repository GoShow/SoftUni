using System;
using System.Linq;

int rows = int.Parse(Console.ReadLine());
int[][] jaggedArr = new int[rows][];

for (int i = 0; i < rows; i++)
{
    jaggedArr[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
}

string command;

while ((command = Console.ReadLine().ToLower()) != "end")
{
    string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string action = tokens[0];
    int row = int.Parse(tokens[1]);
    int col = int.Parse(tokens[2]);
    int value = int.Parse(tokens[3]);

    if (row < 0 || row >= rows || col < 0 || col >= jaggedArr[row].Length)
    {
        Console.WriteLine("Invalid coordinates");

        continue;
    }

    switch (action)
    {
        case "add":
            jaggedArr[row][col] += value;
            break;
        case "subtract":
            jaggedArr[row][col] -= value;
            break;
        default:
            break;
    }
}

foreach (var row in jaggedArr)
{
    Console.WriteLine(string.Join(" ", row));
}
