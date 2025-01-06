using System;
using System.Linq;

int[] dimensions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[,] matrix = new int[dimensions[0], dimensions[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = values[col];
    }
}

for (int col = 0; col < matrix.GetLength(1); col++)
{
    int sum = 0;

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        sum += matrix[row, col];
    }

    Console.WriteLine(sum);
}

