using System;

namespace _06.PrintTriplesOfLatinLetters;

internal class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                for (int k = 0; k < count; k++)
                {
                    char firstChar = (char)('a' + i);
                    char secondChar = (char)('a' + j);
                    char thirdChar = (char)('a' + k);

                    Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                }
            }
        }
    }
}
