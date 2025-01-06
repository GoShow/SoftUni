using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public class Dog : Mammal
{
    private const double DogWeightMultiplier = 0.4;

    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    { }

    protected override double WeightMultiplier
        => DogWeightMultiplier;

    public override bool Eat(IFood food)
    {
        if (food is not Meat)
        {
            return false;
        }

        return base.Eat(food);
    }

    public override string ProduceSound()
        => "Woof!";

    public override string ToString()
        => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
}
