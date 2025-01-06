using System;

namespace _10.LowerOrUpper;

internal class Program
{
    static void Main(string[] args)
    {
        char ch = char.Parse(Console.ReadLine());
        bool isUpper = Char.IsUpper(ch);

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