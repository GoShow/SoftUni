using System;
using System.Collections.Generic;

namespace _04.PiratesUsingClass;

internal class Program
{
    static void Main(string[] args)
    {
        List<City> cities = new();

        string cityInput = null;
        while ((cityInput = Console.ReadLine()) != "Sail")
        {
            string[] tokens = cityInput.Split("||", StringSplitOptions.RemoveEmptyEntries);

            string cityName = tokens[0];
            int people = int.Parse(tokens[1]);
            int gold = int.Parse(tokens[2]);

            City city = cities.Find(c => c.Name == cityName);
            bool shouldAdd = false;

            if (city == null)
            {
                city = new City();
                city.Name = cityName;
                shouldAdd = true;
            }

            city.People += people;
            city.Gold += gold;

            if (shouldAdd)
            {
                cities.Add(city);
            }
        }

        string eventInput = null;
        while ((eventInput = Console.ReadLine()) != "End")
        {
            string[] tokens = eventInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];
            string cityName = tokens[1];
            City city = cities.Find(c => c.Name == cityName);

            if (action == "Plunder")
            {
                int people = int.Parse(tokens[2]);
                int gold = int.Parse(tokens[3]);

                city.People -= people;
                city.Gold -= gold;

                Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {people} citizens killed.");

                if (city.People <= 0 || city.Gold <= 0)
                {
                    cities.Remove(city);

                    Console.WriteLine($"{cityName} has been wiped off the map!");
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

                city.Gold += gold;

                Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {city.Gold} gold.");
            }
        }

        if (cities.Count > 0)
        {
            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

            foreach (City city in cities)
            {
                Console.WriteLine($"{city.Name} -> Population: {city.People} citizens, Gold: {city.Gold} kg");
            }
        }
        else
        {
            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }
}

class City
{
    public string Name { get; set; }
    public int People { get; set; }
    public int Gold { get; set; }
}
