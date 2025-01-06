using System;
using System.Collections.Generic;

namespace _04.HeroesOfCodeAndLogicVIIWithClass;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Hero> heroes = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] heroesProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = heroesProperties[0];
            int hitPoints = int.Parse(heroesProperties[1]);
            int manaPoints = int.Parse(heroesProperties[2]);

            Hero hero = new(name, hitPoints, manaPoints);

            heroes.Add(name, hero);
        }

        string command = null;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0];

            switch (action)
            {
                case "CastSpell":
                    CastSpell(tokens[1], int.Parse(tokens[2]), tokens[3], heroes);
                    break;
                case "TakeDamage":
                    TakeDamage(tokens[1], int.Parse(tokens[2]), tokens[3], heroes);
                    break;
                case "Recharge":
                    Recharge(tokens[1], int.Parse(tokens[2]), heroes);
                    break;
                case "Heal":
                    Heal(tokens[1], int.Parse(tokens[2]), heroes);
                    break;
            }
        }

        foreach (Hero hero in heroes.Values)
        {
            Console.WriteLine(hero.Name);
            Console.WriteLine($"  HP: {hero.HitPoints}");
            Console.WriteLine($"  MP: {hero.ManaPoints}");
        }
    }

    static void CastSpell(string name, int manaNeeded, string spell, Dictionary<string, Hero> heroes)
    {
        Hero hero = heroes[name];

        if (hero.ManaPoints >= manaNeeded)
        {
            hero.ManaPoints -= manaNeeded;

            Console.WriteLine($"{name} has successfully cast {spell} and now has {hero.ManaPoints} MP!");

            return;
        }

        Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
    }

    static void TakeDamage(string name, int damage, string attacker, Dictionary<string, Hero> heroes)
    {
        Hero hero = heroes[name];

        hero.HitPoints -= damage;

        if (hero.HitPoints > 0)
        {
            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {hero.HitPoints} HP left!");

            return;
        }

        Console.WriteLine($"{name} has been killed by {attacker}!");

        heroes.Remove(name);
    }

    static void Recharge(string name, int amount, Dictionary<string, Hero> heroes)
    {
        Hero hero = heroes[name];

        int originalManaPoints = hero.ManaPoints;

        hero.ManaPoints += amount;

        if (hero.ManaPoints > 200)
        {
            hero.ManaPoints = 200;
        }

        Console.WriteLine($"{name} recharged for {hero.ManaPoints - originalManaPoints} MP!");
    }

    static void Heal(string name, int amount, Dictionary<string, Hero> heroes)
    {
        Hero hero = heroes[name];

        int originalHitPoints = hero.HitPoints;

        hero.HitPoints += amount;

        if (hero.HitPoints > 100)
        {
            hero.HitPoints = 100;
        }

        Console.WriteLine($"{name} healed for {hero.HitPoints - originalHitPoints} HP!");
    }
}

class Hero
{
    public Hero(string name, int hitPoints, int manaPoints)
    {
        Name = name;
        HitPoints = hitPoints;
        ManaPoints = manaPoints;
    }

    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int ManaPoints { get; set; }

}
