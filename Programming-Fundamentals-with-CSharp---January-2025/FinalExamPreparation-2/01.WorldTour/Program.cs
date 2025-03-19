using System;

namespace _01.WorldTour;

internal class Program
{
    static void Main(string[] args)
    {
        string command;

        while ((command = Console.ReadLine()) != "Travel")
        {
            string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];

            switch (action)
            {
                case "Add Stop":

                    break;
                case "Remove Stop":

                    break;
                case "Switch":

                    break;
            }
        }

    }
}
