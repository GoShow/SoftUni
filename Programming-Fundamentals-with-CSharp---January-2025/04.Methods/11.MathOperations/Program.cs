using System;

namespace _11.MathOperations;

internal class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        char @operator = char.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine(Calculate(firstNumber, @operator, secondNumber));
    }

    static double Calculate(int firstNumber, char @operator, int secondNumber)
    {
        switch (@operator)
        {
            case '+': return firstNumber + secondNumber;
            case '-': return firstNumber - secondNumber;
            case '*': return firstNumber * secondNumber;
            default: return (double)firstNumber / secondNumber;
        }
    }
}
