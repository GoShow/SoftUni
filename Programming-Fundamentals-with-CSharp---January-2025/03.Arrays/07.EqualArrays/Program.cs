using System;
using System.Linq;

namespace _07.EqualArrays;

internal class Program
{
    static void Main(string[] args)
    {
        int[] firstArray = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int[] secondArray = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        bool areEqual = true;
        int sum = 0;
        int index = 0;

        for (int i = 0; i < firstArray.Length; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                areEqual = false;
                index = i;
                break;
            }

            sum += firstArray[i];
        }
        if (areEqual)
        {

            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
        else
        {
            Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
        }
    }
}
