namespace WildFarm.Models.Interfaces;

public interface IAnimal
{
    string Name { get; }

    double Weight { get; }

    int FoodEaten { get; }

    string ProduceSound();

    bool Eat(IFood food);
}
