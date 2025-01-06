using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public class Owl : Bird
{
    private const double OwlWeightMultiplier = 0.25;

    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    { }

    protected override double WeightMultiplier
    => OwlWeightMultiplier;

    public override bool Eat(IFood food)
    {
        if (food is not Meat)
        {
            return false;
        }

        return base.Eat(food);
    }

    public override string ProduceSound()
        => "Hoot Hoot";
}
