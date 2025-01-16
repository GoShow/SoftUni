using System;

namespace _10.LowerOrUpper;

internal class Program
{
    static void Main(string[] args)
    {
        char ch = char.Parse(Console.ReadLine());
        bool isUpper = char.IsUpper(ch);

        if (isUpper)
        {
            Console.WriteLine("upper-case");
        }
        else
        {
            Console.WriteLine("lower-case");
        }
    }
}