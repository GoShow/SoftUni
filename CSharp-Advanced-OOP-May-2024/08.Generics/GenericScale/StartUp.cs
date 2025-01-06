namespace GenericScale;

public class StartUp
{
    static void Main(string[] args)
    {
        EqualityScale<int> scale = new(33, 22);
        Console.WriteLine(scale.AreEqual());
    }
}
