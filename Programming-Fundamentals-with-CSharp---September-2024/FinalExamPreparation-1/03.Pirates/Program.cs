using System;
using System.Collections.Generic;

namespace _03.Pirates;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int[]> cities = new();

        string cityInput = null;
        while ((cityInput = Console.ReadLine()) != "Sail")
        {
            string[] tokens = cityInput.Split("||", StringSplitOptions.RemoveEmptyEntries);

            string city = tokens[0];
            int population = int.Parse(tokens[1]);
            int gold = int.Parse(tokens[2]);

            if (!cities.ContainsKey(city))
            {
                cities[city] = new int[2];
            }

            cities[city][0] += population;
            cities[city][1] += gold;
        }

        string eventInput = null;
        while ((eventInput = Console.ReadLine()) != "End")
        {
            string[] tokens = eventInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];
            string city = tokens[1];

            if (action == "Plunder")
            {
                int people = int.Parse(tokens[2]);
                int gold = int.Parse(tokens[3]);

                cities[city][0] -= people;
                cities[city][1] -= gold;

                Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                if (cities[city][0] <= 0 || cities[city][1] <= 0)
                {
                    cities.Remove(city);

                    Console.WriteLine($"{city} has been wiped off the map!");
                }
            }
            else
            {
                int gold = int.Parse(tokens[2]);

                if (gold < 0)
                {
                    Console.WriteLine("Gold added cannot be a negative number!");

                    continue;
                }

                cities[city][1] += gold;

                Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city][1]} gold.");
            }
        }

        if (cities.Count > 0)
        {
            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

            foreach (KeyValuePair<string, int[]> city in cities)
            {
                Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
            }
        }
        else
        {
            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }
}
