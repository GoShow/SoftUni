using System;

int size = int.Parse(Console.ReadLine());

char[,] matrix = new char[size, size];

for (int row = 0; row < size; row++)
{
    string values = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = values[col];
    }
}

string searchSymbol = Console.ReadLine();

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        if (matrix[row, col] == searchSymbol[0])
        {
            Console.WriteLine($"({row}, {col})");

            return;
        };
    }
}

Console.WriteLine($"{searchSymbol} does not occur in the matrix");

