using System;
using System.Linq;

namespace _01.ReverseStrings;

internal class Program
{
    static void Main(string[] args)
    {
        string stringToReverse = null;

        while ((stringToReverse = Console.ReadLine()) != "end")
        {
            string reversedString = string.Join("", stringToReverse.Reverse());

            Console.WriteLine($"{stringToReverse} = {reversedString}");
        }
    }
}
