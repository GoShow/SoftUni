using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Mouse : Mammal
{
    private const double MouseWeightMultiplier = 0.1;

    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    { }

    protected override double WeightMultiplier
        => MouseWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

    public override string ProduceSound()
        => "Squeak";

    public override string ToString()
        => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
}
