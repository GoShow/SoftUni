using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Hen : Bird
{
    private const double HenWeightMultiplier = 0.35;

    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    { }

    protected override double WeightMultiplier
        => HenWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

    public override string ProduceSound()
        => "Cluck";
}
