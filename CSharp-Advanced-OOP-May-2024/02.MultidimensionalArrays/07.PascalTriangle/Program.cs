using System;

int size = int.Parse(Console.ReadLine());

long[][] pascalTriangle = new long[size][];

pascalTriangle[0] = new long[1] { 1 };

for (int row = 1; row < size; row++)
{
    pascalTriangle[row] = new long[row + 1];

    for (int col = 0; col < pascalTriangle[row].Length; col++)
    {
        long sum = 0;

        if (col > 0)
        {
            sum += pascalTriangle[row - 1][col - 1];
        }

        if (col < pascalTriangle[row - 1].Length)
        {
            sum += pascalTriangle[row - 1][col];
        }

        pascalTriangle[row][col] = sum;
    }
}

for (int row = 0; row < size; row++)
{
    //Justfor fun - looks legit to input 4 :)
    //Console.Write("".PadLeft(size - row, ' ')); 
    for (int col = 0; col < pascalTriangle[row].Length; col++)
    {
        Console.Write($"{pascalTriangle[row][col]} ");
    }

    Console.WriteLine();
}
