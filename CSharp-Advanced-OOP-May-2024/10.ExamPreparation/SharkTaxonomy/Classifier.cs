using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharkTaxonomy;

public class Classifier
{
    public Classifier(int capacity)
    {
        Capacity = capacity;
        Species = new List<Shark>();
    }

    public int Capacity { get; set; }

    public List<Shark> Species { get; set; }

    public int GetCount => Species.Count;

    public void AddShark(Shark shark)
    {
        if (Species.Count < Capacity && !Species.Any(s => s.Kind == shark.Kind))
        {
            Species.Add(shark);
        }
    }

    public bool RemoveShark(string kind)
    {
        Shark shark = Species.FirstOrDefault(s => s.Kind == kind);

        if (shark != null)
        {
            Species.Remove(shark);

            return true;
        }

        return false;
    }

    public string GetLargestShark() => Species.MaxBy(s => s.Length).ToString();

    public double GetAverageLength() => Species.Average(s => s.Length);

    public string Report()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{GetCount} sharks classified:");

        foreach (Shark shark in Species)
        {
            sb.AppendLine(shark.ToString());
        }

        return sb.ToString().Trim();
    }
}