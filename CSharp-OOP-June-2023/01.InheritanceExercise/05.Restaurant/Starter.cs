namespace Restaurant;

public abstract class Starter : Food
{
    public Starter(string name, decimal price, double grams)
        : base(name, price, grams)
    {
    }
}
