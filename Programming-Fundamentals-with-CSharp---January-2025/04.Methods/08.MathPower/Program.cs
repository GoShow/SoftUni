using System;

namespace _08.MathPower;

internal class Program
{
    static void Main(string[] args)
    {
        double number = double.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());

        Console.WriteLine(Pow(number, power));
    }

    static double Pow(double number, int pow)
    {
        double result = 1;

        for (int i = 0; i < pow; i++)
        {
            result *= number;
        }

        return result;
    }
}