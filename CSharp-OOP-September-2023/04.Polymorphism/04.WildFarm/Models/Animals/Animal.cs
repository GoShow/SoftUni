using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public abstract class Animal : IAnimal
{
    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name { get; private set; }

    public double Weight { get; private set; }

    public int FoodEaten { get; private set; }

    protected abstract double WeightMultiplier { get; }

    public abstract string ProduceSound();

    public virtual bool Eat(IFood food)
    {
        Weight += food.Quantity * WeightMultiplier;
        FoodEaten += food.Quantity;

        return true;
    }

    public override string ToString()
        => $"{GetType().Name} [{Name}, ";
}
