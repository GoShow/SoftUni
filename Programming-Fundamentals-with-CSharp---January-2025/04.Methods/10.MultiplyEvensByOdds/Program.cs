using System;

namespace _10.MultiplyEvensByOdds;

internal class Program
{
    static void Main(string[] args)
    {
        int number = Math.Abs(int.Parse(Console.ReadLine()));

        int evenSum = GetSumOfEvenDigits(number);
        int oddSum = GetSumOfOddDigits(number);

        int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);

        Console.WriteLine(result);
    }

    static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
    {
        return evenSum * oddSum;
    }

    static int GetSumOfEvenDigits(int number)
    {
        int sum = 0;

        while (number > 0)
        {
            int currentDigit = number % 10;
            if (currentDigit % 2 == 0)
            {
                sum += currentDigit;
            }

            number /= 10;
        }

        return sum;
    }

    static int GetSumOfOddDigits(int number)
    {
        int sum = 0;

        while (number > 0)
        {
            int currentDigit = number % 10;
            if (currentDigit % 2 != 0)
            {
                sum += currentDigit;
            }

            number /= 10;
        }

        return sum;
    }
}
