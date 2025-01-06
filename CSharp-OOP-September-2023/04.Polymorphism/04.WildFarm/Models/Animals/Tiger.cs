using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public class Tiger : Feline
{
    private const double TigerWeightMultiplier = 1;

    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    { }

    protected override double WeightMultiplier
        => TigerWeightMultiplier;

    public override bool Eat(IFood food)
    {
        if (food is not Meat)
        {
            return false;
        }

        return base.Eat(food);
    }

    public override string ProduceSound()
        => "ROAR!!!";
}
