using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

char[,] cupboard = new char[dimensions[0], dimensions[1]];
int mouseRow = 0;
int mouseCol = 0;
int cheeseCount = 0;

for (int row = 0; row < rows; row++)
{
    string currentRow = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        cupboard[row, col] = currentRow[col];

        if (currentRow[col] == 'M')
        {
            mouseRow = row;
            mouseCol = col;
            cupboard[mouseRow, mouseCol] = '*';
        }
        if (cupboard[row, col] == 'C')
        {
            cheeseCount++;
        }
    }
}
string command;
while ((command = Console.ReadLine()) != "danger")
{
    if (command == "left")
    {
        if (mouseCol == 0)
        {
            Console.WriteLine("No more cheese for tonight!");
            break;
        }

        if (cupboard[mouseRow, mouseCol - 1] == '@')
        {
            continue;
        }

        mouseCol--;
    }
    else if (command == "right")
    {
        if (mouseCol == cols - 1)
        {
            Console.WriteLine("No more cheese for tonight!");
            
            break;
        }

        if (cupboard[mouseRow, mouseCol + 1] == '@')
        {
            continue;
        }

        mouseCol++;
    }
    else if (command == "up")
    {
        if (mouseRow == 0)
        {
            Console.WriteLine("No more cheese for tonight!");
            
            break;
        }

        if (cupboard[mouseRow - 1, mouseCol] == '@')
        {
            continue;
        }

        mouseRow--;
    }
    else if (command == "down")
    { 
        if (mouseRow == rows - 1)
        {
            Console.WriteLine("No more cheese for tonight!");
            break;
        }

        if (cupboard[mouseRow + 1, mouseCol] == '@')
        {
            continue;
        }

        mouseRow++;
    }

    if (cupboard[mouseRow, mouseCol] == 'C')
    {
        cheeseCount--;
        cupboard[mouseRow, mouseCol] = '*';

        if (cheeseCount == 0)
        {
            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
            break;
        }
        
        continue;
    }
    if (cupboard[mouseRow, mouseCol] == 'T')
    {
        Console.WriteLine("Mouse is trapped!");
        
        break;
    }
}

if (command == "danger")
{
    Console.WriteLine("Mouse will come back later!");
}

cupboard[mouseRow, mouseCol] = 'M';

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        Console.Write(cupboard[row, col]);
    }

    Console.WriteLine();    
}
