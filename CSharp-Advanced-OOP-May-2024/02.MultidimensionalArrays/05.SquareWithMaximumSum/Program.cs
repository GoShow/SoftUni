
using System;
using System.Linq;

int[] dimensions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[,] matrix = new int[dimensions[0], dimensions[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] values = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = values[col];
    }
}

int maxSum = int.MinValue;
int maxSumRow = 0;
int maxSumCol = 0;

for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        int currSum =
            matrix[row, col] + matrix[row, col + 1] +
            matrix[row + 1, col] + matrix[row + 1, col + 1];

        if (currSum > maxSum)
        {
            maxSumRow = row;
            maxSumCol = col;
            maxSum = currSum;
        }
    }
}

Console.WriteLine($"{matrix[maxSumRow, maxSumCol]} {matrix[maxSumRow, maxSumCol + 1]}");
Console.WriteLine($"{matrix[maxSumRow + 1, maxSumCol]} {matrix[maxSumRow + 1, maxSumCol + 1]}");
Console.WriteLine(maxSum);

