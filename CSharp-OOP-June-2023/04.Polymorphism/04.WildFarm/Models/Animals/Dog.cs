using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Dog : Mammal
{
    private const double DogWeightMultiplier = 0.4;

    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    { }

    protected override double WeightMultiplier
        => DogWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type>() { typeof(Meat) };

    public override string ProduceSound()
        => "Woof!";

    public override string ToString()
        => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
}
