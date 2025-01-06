using System;
using System.Collections.Generic;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;

    private readonly IAnimalFactory animalFactory;
    private readonly IFoodFactory foodFactory;

    private readonly ICollection<IAnimal> animals;

    public Engine(
        IReader reader,
        IWriter writer,
        IAnimalFactory animalFactory,
        IFoodFactory foodFactory)
    {
        this.reader = reader;
        this.writer = writer;

        this.animalFactory = animalFactory;
        this.foodFactory = foodFactory;

        animals = new List<IAnimal>();
    }

    public void Run()
    {
        string command;
        while ((command = reader.ReadLine()) != "End")
        {
            IAnimal animal = CreateAnimal(command);
            IFood food = CreateFood();

            writer.WriteLine(animal.ProduceSound());

            bool isEaten = animal.Eat(food);

            if (!isEaten)
            {
                writer.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
            }

            animals.Add(animal);
        }

        foreach (IAnimal animal in animals)
        {
            writer.WriteLine(animal);
        }
    }

    private IAnimal CreateAnimal(string command)
    {
        string[] animalArgs = command
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        IAnimal animal = animalFactory.CreateAnimal(animalArgs);

        return animal;
    }

    private IFood CreateFood()
    {
        string[] foodTokens = reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string foodType = foodTokens[0];
        int foodQuantity = int.Parse(foodTokens[1]);

        IFood food = foodFactory.CreateFood(foodType, foodQuantity);

        return food;
    }
}
