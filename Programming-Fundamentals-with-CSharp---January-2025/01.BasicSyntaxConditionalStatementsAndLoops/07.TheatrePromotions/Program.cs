using System;

namespace _07.TheatrePromotions;

internal class Program
{
    static void Main(string[] args)
    {
        string dayType = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string result = string.Empty;

        if (age >= 0 && age <= 18)
        {
            if (dayType == "Weekday")
            {
                result = "12$";
            }
            else if (dayType == "Weekend")
            {
                result = "15$";
            }
            else if (dayType == "Holiday")
            {
                result = "5$";
            }
        }
        else if (age > 18 && age <= 64)
        {
            if (dayType == "Weekday")
            {
                result = "18$";
            }
            else if (dayType == "Weekend")
            {
                result = "20$";
            }
            else if (dayType == "Holiday")
            {
                result = "12$";
            }
        }
        else if (age > 64 && age <= 122)
        {
            if (dayType == "Weekday")
            {
                result = "12$";
            }
            else if (dayType == "Weekend")
            {
                result = "15$";
            }
            else if (dayType == "Holiday")
            {
                result = "10$";
            }
        }
        else
        {
            result = "Error!";
        }

        Console.WriteLine(result);
    }
}