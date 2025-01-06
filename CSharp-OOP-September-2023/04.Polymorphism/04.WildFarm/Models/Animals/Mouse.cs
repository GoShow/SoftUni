using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public class Mouse : Mammal
{
    private const double MouseWeightMultiplier = 0.1;

    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    { }

    protected override double WeightMultiplier
        => MouseWeightMultiplier;

    public override bool Eat(IFood food)
    {
        if (food is not Vegetable and not Fruit)
        {
            return false;
        }

        return base.Eat(food);
    }

    public override string ProduceSound()
        => "Squeak";

    public override string ToString()
        => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
}
