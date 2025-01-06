using System;

namespace SharkTaxonomy;

public class Shark
{
    public Shark(string kind, int length, string food, string habitat)
    {
        Kind = kind;
        Length = length;
        Food = food;
        Habitat = habitat;
    }

    public string Kind { get; set; }
    public int Length { get; set; }
    public string Food { get; set; }
    public string Habitat { get; set; }

    public override string ToString() =>
        $"{Kind} shark: {Length}m long.{Environment.NewLine}Could be spotted in the {Habitat}, typical menu: {Food}";
}
