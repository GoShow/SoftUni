using System;

int size = int.Parse(Console.ReadLine());

char[,] matrix = new char[size, size];

int jetRow = 0;
int jetCol = 0;

int enemiesCount = 0;

int armor = 300;

for (int row = 0; row < size; row++)
{
    string values = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        char currentValue = values[col];
        matrix[row, col] = currentValue;

        if (currentValue == 'J')
        {
            jetRow = row;
            jetCol = col;
        }
        else if (currentValue == 'E')
        {
            enemiesCount++;
        }
    }
}

while (enemiesCount > 0 && armor > 0)
{
    string direction = Console.ReadLine();

    matrix[jetRow, jetCol] = '-';

    switch (direction)
    {
        case "up":
            jetRow--;
            break;
        case "down":
            jetRow++;
            break;
        case "left":
            jetCol--;
            break;
        case "right":
            jetCol++;
            break;
    }

    if (matrix[jetRow, jetCol] == 'E')
    {
        enemiesCount--;
        armor -= 100;

        if (enemiesCount == 0 || armor == 0)
        {
            matrix[jetRow, jetCol] = 'J';

            break;
        }
    }

    if (matrix[jetRow, jetCol] == 'R')
    {
        armor = 300;
    }

    matrix[jetRow, jetCol] = 'J';
}

if (armor == 0)
{
    Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetRow}, {jetCol}]!");
}
else
{
    Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
}

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        Console.Write(matrix[row, col]);
    }

    Console.WriteLine();
}
