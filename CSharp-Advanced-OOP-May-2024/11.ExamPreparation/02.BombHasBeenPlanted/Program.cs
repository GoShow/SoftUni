using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] dimensions = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        int rows = dimensions[0];
        int cols = dimensions[1];

        int ctStartRow = 0;
        int ctStartCol = 0;
        int bombRow = 0;
        int bombCol = 0;

        char[,] matrix = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string rowData = Console.ReadLine();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowData[col];

                if (matrix[row, col] == 'C')
                {
                    ctStartRow = row;
                    ctStartCol = col;
                }
                else if (matrix[row, col] == 'B')
                {
                    bombRow = row;
                    bombCol = col;
                }
            }
        }

        PlayGame(ctStartRow, ctStartCol, bombRow, bombCol, matrix);
        PrintMatrix(matrix);
    }

    static void PlayGame(int ctRow, int ctCol, int bombRow, int bombCol, char[,] matrix)
    {
        int seconds = 16;
        bool isDefused = false;
        bool isDead = false;

        while (seconds > 0)
        {
            seconds--;
            int prevRow = ctRow;
            int prevCol = ctCol;

            string command = Console.ReadLine();

            switch (command)
            {
                case "up": ctRow--; break;
                case "down": ctRow++; break;
                case "left": ctCol--; break;
                case "right": ctCol++; break;
                case "defuse":
                    if (matrix[ctRow, ctCol] == 'B')
                    {
                        seconds -= 3;
                        if (seconds >= 0)
                        {
                            matrix[bombRow, bombCol] = 'D';
                            isDefused = true;
                        }
                    }
                    else
                    {
                        seconds--;
                    }
                    break;
            }

            if (ctRow < 0 || ctRow >= matrix.GetLength(0) || ctCol < 0 || ctCol >= matrix.GetLength(1))
            {
                ctRow = prevRow;
                ctCol = prevCol;
            }
            if (matrix[ctRow, ctCol] == 'T')
            {
                matrix[ctRow, ctCol] = '*';
                isDead = true;
                break;
            }
            if (isDefused)
            {
                break;
            }
        }

        if (isDead)
        {
            Console.WriteLine("Terrorists win!");
        }
        else if (isDefused)
        {
            Console.WriteLine("Counter-terrorist wins!");
            Console.WriteLine($"Bomb has been defused: {seconds} second/s remaining.");
        }
        else
        {
            if (seconds < 0)
            {
                matrix[bombRow, bombCol] = 'X';
            }

            Console.WriteLine("Terrorists win!");
            Console.WriteLine("Bomb was not defused successfully!");
            Console.WriteLine($"Time needed: {Math.Abs(seconds)} second/s.");
        }
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}
