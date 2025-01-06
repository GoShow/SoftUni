using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public class Cat : Feline
{
    private const double CatWeightMultiplier = 0.3;

    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed) { }

    protected override double WeightMultiplier
        => CatWeightMultiplier;

    public override bool Eat(IFood food)
    {
        if (food is not Vegetable and not Meat)
        {
            return false;
        }

        return base.Eat(food);
    }

    public override string ProduceSound()
        => "Meow";
}
