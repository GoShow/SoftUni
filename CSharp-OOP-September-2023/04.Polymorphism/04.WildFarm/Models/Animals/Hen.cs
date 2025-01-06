namespace WildFarm.Models.Animals;

public class Hen : Bird
{
    private const double HenWeightMultiplier = 0.35;

    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    { }

    protected override double WeightMultiplier
        => HenWeightMultiplier;

    public override string ProduceSound()
        => "Cluck";
}
