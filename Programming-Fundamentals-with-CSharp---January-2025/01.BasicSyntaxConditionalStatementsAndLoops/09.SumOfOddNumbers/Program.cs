using System;

namespace _09.SumOfOddNumbers;

internal class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        int sumOfOdd = 0;
        int number = 0;

        while (count > 0)
        {
            if (number % 2 != 0)
            {
                Console.WriteLine(number);
                sumOfOdd += number;
                count--;
            }

            number++;
        }

        Console.WriteLine($"Sum: {sumOfOdd}");
    }
}
