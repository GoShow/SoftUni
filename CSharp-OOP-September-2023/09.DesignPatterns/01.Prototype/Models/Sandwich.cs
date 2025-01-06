using System;

namespace Prototype.Models;

//[Serializable]
public class Sandwich : SandwichPrototype
{
    private string bread;
    private string meat;
    private string cheese;
    private string veggies;

    public Sandwich(string bread, string meat, string cheese, string veggies)
    {
        this.bread = bread;
        this.meat = meat;
        this.cheese = cheese;
        this.veggies = veggies;
        //this.Prices = new();
    }

    //public List<decimal> Prices { get; set; }

    public override SandwichPrototype Clone()
    {
        Console.WriteLine($"Cloning sandwich with ingredients: {GetIngredients()}");

        return MemberwiseClone() as SandwichPrototype;
    }

    //public override SandwichPrototype DeepClone()
    //{
    //    Console.WriteLine($"Cloning sandwich with ingredients: {GetIngredients()}");

    //    using (var ms = new MemoryStream())
    //    {
    //        var formatter = new BinaryFormatter();
    //        formatter.Serialize(ms, this);
    //        ms.Position = 0;

    //        return formatter.Deserialize(ms) as SandwichPrototype;
    //    }
    //}

    private string GetIngredients()
        => $"{bread}, {meat}, {cheese}, {veggies}";
}
