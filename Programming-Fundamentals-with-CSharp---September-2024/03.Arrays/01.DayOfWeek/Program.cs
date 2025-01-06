using System;

namespace _01.DayOfWeek;

internal class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        string[] days =
        {
          "Monday",
          "Tuesday",
          "Wednesday",
          "Thursday",
          "Friday",
          "Saturday",
          "Sunday"
        };

        if (number >= 1 && number <= 7)
        {
            int index = number - 1;

            Console.WriteLine(days[index]);
        }
        else
        {
            Console.WriteLine("Invalid day!");
        }
    }
}
